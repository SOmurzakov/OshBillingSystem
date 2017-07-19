using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using OshCommons;
using OshBusinessLogic.Providers;

namespace OshChannel.Billing
{
    public class BillingHandler : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            try
            {
                Logger.Write("New request received");
                context.Response.ContentType = "application/xml";
                context.Response.ContentEncoding = System.Text.Encoding.UTF8;

                string ip = context.Request.UserHostAddress;
                string request = GetRequest(context.Request);
                Logger.Write("{0}:\n{1}", ip, request);

                string response = "";
                if (string.IsNullOrWhiteSpace(request))
                {
                    Logger.Write("Request is null");
                    response = "Request is empty";
                }
                else
                {
                    response = new BillingProvider().GetResponse(request, ip);
                    Logger.Write("Response:\n{0}", response);
                }

                byte[] responseBytes = System.Text.Encoding.UTF8.GetBytes(response);
                context.Response.OutputStream.Write(responseBytes, 0, responseBytes.Length);
            }
            catch (Exception ex)
            {
                Logger.Write("Exception while processing request\n{0}", ex.ToString());
                context.Response.Write("500: Internal server error");
            }
        }

        public bool IsReusable
        {
            get
            {
                return false;
            }
        }

        private string GetRequest(HttpRequest rawRequest)
        {
            int length = Convert.ToInt32(rawRequest.InputStream.Length);
            byte[] bytes = new byte[length];
            rawRequest.InputStream.Read(bytes, 0, length);
            string s = System.Text.Encoding.UTF8.GetString(bytes);
            return s;
        }

    }
}