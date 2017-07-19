using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Xml;
using OshBusinessModel.Da;
using OshBusinessModel.Da.Billing;
using System.Globalization;
using OshCommons;
using System.Configuration;
using OshBusinessModel.Da.Invoices;
using System.Web;

namespace OshBusinessLogic.Providers
{
    public class BillingProvider
    {
        private string qidPath = "/XML/HEAD/@QID";
        private string requisitePath = "/XML/BODY/@PARAM1";
        private string sumPath = "/XML/BODY/@SUM";
        private string datePath = "/XML/HEAD/@DTS";
        private string operationPath = "/XML/HEAD/@OP";
        //private string transactionsPath = "XML/BODY/TRANSACTIONS/";

        public string GetResponse(string request, string ip)
        {

            var billingTerminalsDa = NativeSql.Exec("terminals_getTerminalByIp", new {ip}).OneRow<BillingTerminalsDa>();

            if (billingTerminalsDa == null)
            {
                return GetResponseWithErrorMessage(string.Format("Your service {0} has no access. Contact customs service to provider more information", ip), 400, GetDate(DateTime.Now), "", "", "");
            }
            else
            {
                XmlDocument xml = new XmlDocument();
                xml.LoadXml(request);

                string qidString = GetValueFromXml(qidPath, xml);

                var billingRequest = NativeSql.Exec("terminals_getRequest", new {subagentId = billingTerminalsDa.SubagentId, qid = qidString, }).OneRow<BillingRequestDa>();

                if (billingRequest != null)
                {
                    Logger.Write("Duplicate request");
                    return billingRequest.Response;
                }
                else
                {
                    billingRequest = new BillingRequestDa();
                    billingRequest.Request = request;
                    billingRequest.Response = "";
                    billingRequest.Date = DateTime.Now;
                    billingRequest.SubagentId = billingTerminalsDa.SubagentId;

                    ProcessRequest(xml, billingRequest, billingTerminalsDa);

                    if (billingRequest.ProcessStatus != 400 && billingRequest.ProcessStatus != 250)
                    {
                        NativeSql.Exec("terminals_saveRequest", new
                                                                    {
                                                                        date = billingRequest.Date,
                                                                        operation = billingRequest.Operation,
                                                                        processStatus = billingRequest.ProcessStatus,
                                                                        qid = billingRequest.Qid,
                                                                        request = billingRequest.Request,
                                                                        response = billingRequest.Response,
                                                                        subagentId = billingRequest.SubagentId,
                                                                        amount = billingRequest.Amount,
                                                                        contractId = billingRequest.ContractId,
                                                                    });
                    }

                    return billingRequest.Response;
                }
            }
        }

        private void ProcessRequest(XmlDocument xml, BillingRequestDa request, BillingTerminalsDa billingTerminalsDa)
        {
            string operation = GetValueFromXml(operationPath, xml);
            string qid = GetValueFromXml(qidPath, xml);
            string requisite = GetValueFromXml(requisitePath, xml);
            string date = GetValueFromXml(datePath, xml);
            string sumString = GetValueFromXml(sumPath, xml);
            double sum = string.IsNullOrEmpty(sumString) ? 0 : double.Parse(sumString, new CultureInfo("en-US"));

            request.Qid = qid;
            request.Operation = operation;
            request.Amount = sum;
            request.Response = "";

            Logger.Write("New request received\nqid = {0}\nrequisite = {1}\noperation = {2}\nsum = {3}", qid, requisite, operation, sum);

            int processStatus;
            string response;

            switch (operation)
            {
                case "QE10":
                    ProcessPaymentRequest(operation, qid, requisite, date, sum, out processStatus, out response, billingTerminalsDa, request);
                    break;

                case "QE11":
                    ProcessRequisiteValidationRequest(operation, qid, requisite, date, out processStatus, out response, billingTerminalsDa.Sid, request);
                    break;

/*
                case "RS25":
                    ProcessReconsiliationRequest(xml, out processStatus, out response);
                    break;
*/

                default:
                    GetWrongRequestMessage(operation, qid, requisite, date, out processStatus, out response, billingTerminalsDa.Sid);
                    break;
            }

            request.ProcessStatus = processStatus;
            request.Response = response;

            Logger.Write("Request {0} processed with status {1}", qid, processStatus);
        }

        private void ProcessPaymentRequest(string operation, string qid, string requisite, string date, double amount, out int processStatus, out string response, BillingTerminalsDa billingTerminalsDa, BillingRequestDa request)
        {
            try
            {
                if (RequisiteIsValidByFormat(requisite))
                {
                    int contractId = int.Parse(requisite);
                    string subscriberName;
                    if (ContractExists(contractId, out subscriberName))
                    {
                        request.ContractId = contractId;
                        processStatus = 250;
                        request.ProcessStatus = processStatus;
                        response = GetResponse("Payment accepted", request.ProcessStatus, date, request.Operation, request.Qid, billingTerminalsDa.Sid);
                        request.Response = response;

                        if (!billingTerminalsDa.HasBalance || billingTerminalsDa.CurrentBalance >= amount)
                        {
                            ResultDa result =
                                NativeSql.Exec("terminals_registerTransactionAndRequest", 
                                    new
                                    {
                                        date = request.Date,
                                        operation = request.Operation,
                                        processStatus,
                                        qid = request.Qid,
                                        request = request.Request,
                                        response = request.Response,
                                        subagentId = request.SubagentId,
                                        amount = request.Amount,
                                        contractId = request.ContractId,
                                }).OneRow<ResultDa>();

                            if (!result.Success)
                            {
                                processStatus = 400;
                                Logger.Write("Billing", "Transaction request was failed to save\n{0}", result.Message ?? "");
                            }
                        }
                        else
                        {
                            processStatus = 400;
                            response = GetResponseWithErrorMessage(string.Format("Пополните баланс. Ваш баланс составляет {0:0.##} сом", billingTerminalsDa.CurrentBalance), processStatus, date, operation, qid, billingTerminalsDa.Sid);
                        }
                    }
                    else
                    {
                        processStatus = 420;
                        response = GetResponseWithErrorMessage(string.Format("Абонент {0} не найден", requisite), processStatus, date, operation, qid, billingTerminalsDa.Sid);
                    }
                }
                else
                {
                    processStatus = 420;
                    response = GetResponseWithErrorMessage(string.Format("Не верный формат {0}", requisite), 420, date, operation, qid, billingTerminalsDa.Sid);
                }
            }
            catch (Exception ex)
            {
                processStatus = 400;
                response = GetResponse("Exception while processing the payment", processStatus, date, operation, qid, billingTerminalsDa.Sid);
                Logger.Write("Exception whlie processing payment\n{0}", ex);
            }
        }

        private void ProcessRequisiteValidationRequest(string operation, string qid, string requisite, string date, out int processStatus, out string response, string sid, BillingRequestDa request)
        {
            try
            {
                if (RequisiteIsValidByFormat(requisite))
                {
                    int contractId = int.Parse(requisite);
                    request.ContractId = contractId;
                    string subscriberName;
                    if (ContractExists(contractId, out subscriberName))
                    {
                        processStatus = 200;
                        subscriberName = HttpUtility.HtmlEncode(subscriberName);
                        response = GetResponse(subscriberName, processStatus, date, operation, qid, sid);
                    }
                    else
                    {
                        processStatus = 420;
                        response = GetResponseWithErrorMessage(string.Format("Абонент {0} не найден", requisite), processStatus, date, operation, qid, sid);
                    }
                }
                else
                {
                    processStatus = 420;
                    response = GetResponseWithErrorMessage(string.Format("Не верный формат {0}", requisite), 420, date, operation, qid, sid);
                }
            }
            catch (Exception ex)
            {
                processStatus = 400;
                response = GetResponse("Exception while processing the payment", processStatus, date, operation, qid, sid);
                Logger.Write("Exception whlie processing payment\n{0}", ex);
            }
        }

        private void GetWrongRequestMessage(string operation, string qid, string requisite, string date, out int processStatus, out string response, string sid)
        {
            processStatus = 401;
            response = GetResponse("Not supported operation", processStatus, date, operation, qid, sid);
        }

/*
        private void ProcessReconsiliationRequest(XmlDocument xml, out int processStatus, out string response)
        {
            BillingRequestsProvider billings = new BillingRequestsProvider();
            string paymentsNotFound = "";

            XmlNodeList nodes = xml.SelectNodes(transactionsPath);
            foreach (XmlNode transaction in nodes)
            {
                string qid = transaction.Attributes["TRANSACTION_ID"].Value;
                string requisite = transaction.Attributes["ATTRIBUTE_VALUE"].Value;
                string sum = transaction.Attributes["SUM"].Value;
                string date = transaction.Attributes["REGISTER_DATE"].Value;
                double sumDouble = double.Parse(sum, new CultureInfo("en-US"));
                decimal sumDecimal = Convert.ToDecimal(sumDouble);

                if (!billings.PaymentExists(qid, requisite, sumDecimal, context))
                {
                    paymentsNotFound += string.Format("{0} {1} {2} {3}\n", qid, date, requisite, sum);
                }
            }

            if (string.IsNullOrEmpty(paymentsNotFound))
            {
                paymentsNotFound = "Payments are not registered: \n" + paymentsNotFound;

                string needToSendEmailNotification = ConfigurationManager.AppSettings["SendReconciliationFailedMessageToEmail"].ToLower();
                if (needToSendEmailNotification == "true")
                {
                    string toEmail = ConfigurationManager.AppSettings["EmailTo"];
                    string fromEmail = ConfigurationManager.AppSettings["EmailFrom"];
                    string subject = ConfigurationManager.AppSettings["EmailSubject"];
                    string body = paymentsNotFound;
                    EmailSender.SendEmail(toEmail, fromEmail, body, subject);
                }
            }

            processStatus = 200;
            response = ResponseFactory.GetResponse("Reconsiliation succeeded", 200, GetDate(DateTime.Now), "RS25", GetValue(qidPath, xml));
        }
*/

        private string GetValueFromXml(string key, XmlDocument xml)
        {
            XmlNode node = xml.SelectSingleNode(key);
            if (node == null)
            {
                return "";
            }

            return node.Value;
        }

        private string GetDate(DateTime date)
        {
            return date.ToString("yyyy-MM-dd HH:mm:ss");
        }

        private bool RequisiteIsValidByFormat(string requisite)
        {

            if (string.IsNullOrEmpty(requisite) || requisite.Length < "123456".Length)
            {
                return false;
            }

            int t;
            return int.TryParse(requisite, out t);
        }

        private bool ContractExists(int contractId, out string subscriberName)
        {
            subscriberName = "";

            var s =
                NativeSql.Exec("terminals_getSubscriberNameByContractId", new {contractId,}).OneRow
                    <SubscriberNameByContractIdDa>();

            if (s != null)
            {
                subscriberName = s.SubscriberName;
            }

            return s != null;
        }

        public static string GetResponse(string message, int status, string date, string operation, string qid, string sid)
        {
            string response = Resources.ResponseTemplate;
            return ReplaceFields(response, message, status, date, operation, qid, sid);
        }

        public static string GetResponseWithErrorMessage(string message, int status, string date, string operation, string qid, string sid)
        {
            string response = Resources.ErrMessageResponseTemplate;
            return ReplaceFields(response, message, status, date, operation, qid, sid);
        }

        private static string ReplaceFields(string response, string message, int status, string date, string operation, string qid, string sid)
        {
            response = response
                .Replace("{MESSAGE}", message)
                .Replace("{STATUS}", status.ToString())
                .Replace("{DTS}", date)
                .Replace("{OPERATION}", operation)
                .Replace("{QID}", qid)
                .Replace("{SID}", sid)
                .Replace("{ERROR_MESSAGE}", message);

            return response;
        }

        public InvoiceDa GetInvoiceForSubscriber(int subscriberId)
        {
            var tables = NativeSql.ExecMultiple("billing_printLastInvoice", new {subscriberId});
            var invoice = tables[0].OneRow<InvoiceDa>();
            invoice.Contracts = tables[1].Rows<InvoiceContractDa>();
            return invoice;
        }
    }
}
