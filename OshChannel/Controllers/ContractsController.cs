using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using OshBusinessLogic.Providers;
using OshBusinessModel.Da;
using OshChannel.Models;
using OshChannel.Helpers;
using OshBusinessModel.J2MeDb.Dto;
using OshBusinessLogic.Helpers;
using OshBusinessModel.Da.CreateContract;
using OshBusinessModel.Da.Meters;

namespace OshChannel.Controllers
{
    public class ContractsController : ControllerExtended
    {

        [Authorize]
        public ActionResult Show(int contractId)
        {
            return View(new ContractsProvider().GetContract(contractId));
        }

        [Authorize] [HttpPost]
        public ActionResult MakePaymentAjax(MakePaymentModel model)
        {
            try
            {
                int subagentId = model.SubagentId > 0 ? model.SubagentId : 0;
                int userId = model.SubagentId > 0 ? Auth.User.UserId : -model.SubagentId;
                new ContractsProvider().MakePayment(model.ContractId, Misc.ToDouble(model.Amount), userId, subagentId, Auth.User.UserId, model.ReceiptNo ?? "");
                return Json(new {Success = true, Message = "",});
            }
            catch (Exception ex)
            {
                return Json(new {Success = false, ex.Message});
            }
        }

        [Authorize]
        [HttpPost]
        public ActionResult DeleteTransactionAjax(DeleteTransactionAjaxModel model)
        {
            try
            {
                new ContractsProvider().DeleteTransaction(model.ContractId, model.TransactionId, Auth.User.UserId);
                return Json(new { Success = true, Message = "", });
            }
            catch (Exception ex)
            {
                return Json(new { Success = false, ex.Message });
            }
        }

        [Authorize]
        [HttpPost]
        public ActionResult GetMetersValues(GetMetersValuesModel model)
        {
            return PartialView("SetMetersValuesPartial", new ContractsProvider().GetMetersValues(model.ContractId));
        }

        [Authorize, HttpPost]
        public ActionResult SetMetersValues(SetMetersValuesModel model)
        {
            try
            {
                var meters = model.Meters.Select(m => new SetMetersValuesDa() { MeterId = m.MeterId, Value = Misc.ToDouble(m.Value), }).ToArray();
                var dateAsOf = DateTime.Parse(model.Date);
                var res = new ContractsProvider().SetMetersValues(Auth.User.UserId, dateAsOf, meters, model.MeterValueType);
                return Json(res);
            }
            catch (Exception ex)
            {
                return Json(new {Success = false, Message = ex.Message,});
            }
        }

        [Authorize]
        public ActionResult Debtors(int threshold, int startPeriodId = -1, int endPeriodId = -1)
        {
            return View(new ContractsProvider().GetDebtors(threshold, startPeriodId, endPeriodId));
        }

        [Authorize]
        public ActionResult Create(int subscriberId = -1)
        {
            return View(new ContractsProvider().GetDataForCreateContract(subscriberId));
        }

        [Authorize]
        public ActionResult CreateContractAjax(CreateContractAjaxModel request)
        {
            try
            {

                if (string.IsNullOrWhiteSpace(request.Contract.Tariff) || request.Contract.Tariff == "-1")
                {
                    return Json(false, "Выберите тариф");
                }

                if (string.IsNullOrWhiteSpace(request.RegistrationDebt))
                {
                    request.RegistrationDebt = "0";
                }

                var meters = request.Meters == null
                                 ? new CreateContractMeterInfoDa[] {}
                                 : request.Meters.Select(
                                     m =>
                                     new CreateContractMeterInfoDa()
                                         {SerialNumber = m.SerialNumber ?? "", InitialValue = Misc.ToDouble(m.InitialValue),})
                                       .ToArray();

                var options = request.Options == null
                                  ? new CPCAM_TariffOptionDa[] {}
                                  : request.Options.Select(
                                      o =>
                                      new CPCAM_TariffOptionDa()
                                          {SemanticId = o.SemanticId, Value = Misc.ToDouble(o.Value), Sewage = o.Sewage}).ToArray();

                var createContractDa =
                    request.SubscriberId == 0
                        ? new ContractsProvider().CreateWithSubscriber(
                            request.Subscriber.Type,
                            Auth.User.UserId,
                            request.Subscriber.Name ?? "", request.Subscriber.PassportNumber ?? "",
                            request.Subscriber.PassportWhere ?? "",
                            Misc.ToDateTime(request.Subscriber.PassportDate),
                            request.Subscriber.AddressStreet ?? "", request.Subscriber.AddressBuilding ?? "",
                            request.Subscriber.AddressFlat ?? "",
                            request.Subscriber.Phone ?? "",
                            request.Subscriber.Inn ?? "", request.Subscriber.Ugkns ?? "",
                            request.Subscriber.Mfo ?? "", request.Subscriber.Invoice > 0,
                            request.Contract.Name ?? "",
                            request.Contract.AreaId, request.Contract.AddressStreet ?? "",
                            request.Contract.AddressBuilding ?? "",
                            request.Contract.AddressFlat ?? "", request.Contract.Phone ?? "",
                            request.Contract.Tariff, request.Contract.PeopleRegistered,
                            Misc.ToDouble(request.Contract.FixedConsumption),
                            meters, options,
                            Misc.ToDouble(request.RegistrationDebt),
                            request.Contract.ArchiveId, request.Contract.BudgetType ?? "", request.Contract.HasSewage == "1", Misc.ToDouble(request.Contract.Allowance), request.Contract.AllowanceReason ?? "",
                            Misc.ToDouble(request.Contract.FixedConsumptionSewage),
                            request.Subscriber.UgknsName ?? "", request.Subscriber.BankCode ?? "", request.Subscriber.BankName ?? "", request.Subscriber.BankAccount ?? "",
                            Misc.ToDateTime(request.RegistrationDate).Value
                              )
                        : new ContractsProvider().AddContractToSubscriber(Auth.User.UserId, request.SubscriberId,
                                                                           request.Contract.Name ?? "",
                                                                           request.Contract.AreaId,
                                                                           request.Contract.AddressStreet ?? "",
                                                                           request.Contract.AddressBuilding ?? "",
                                                                           request.Contract.AddressFlat ?? "",
                                                                           request.Contract.Phone ?? "",
                                                                           request.Contract.Tariff,
                                                                           request.Contract.PeopleRegistered,
                                                                           Misc.ToDouble(request.Contract.FixedConsumption),
                                                                           meters,
                                                                           options, request.RegistrationDebt,
                                                                           request.Contract.ArchiveId, request.Contract.BudgetType ?? "", request.Contract.HasSewage == "1", 
                                                                           Misc.ToDouble(request.Contract.Allowance), request.Contract.AllowanceReason ?? "",
                                                                           Misc.ToDouble(request.Contract.FixedConsumptionSewage),
                                                                           Misc.ToDateTime(request.RegistrationDate).Value
                                                                           );

                return Json(createContractDa);
            }
            catch (Exception ex)
            {
                return Json(new { ContractId = -1, Message = ex.Message });
            }
        }

        [Authorize, HttpPost]
        public ActionResult Search(SearchContractModel model)
        {
            var results = new ContractsProvider().Search(model.Key ?? "", 
                                                         model.Street ?? "", 
                                                         model.Building ?? "", 
                                                         model.Appartment ?? "",
                                                         model.AreaName ?? "",
                                                         model.ContractName ?? "",
                                                         model.ControllerName ?? "",
                                                         model.Bill ?? "");

            if (results.Contracts.Length == 1 && results.Subscribers.Length == 0)
            {
                return RedirectToAction("Show", "Contracts", new {contractId = results.Contracts[0].ContractId,});
            }
            else if (results.Contracts.Length == 0 && results.Subscribers.Length == 1)
            {
                return RedirectToAction("Show", "Subscribers", new {subscriberId = results.Subscribers[0].SubscriberId,});
            }

            return View(results);
        }

        [Authorize, HttpPost]
        public ActionResult ChangeInfoAjax(ChangeContractInfoAjaxModel model)
        {
            try
            {
                new ContractsProvider().ChangeDetails(Auth.User.UserId, model.ContractId, model.ContractName ?? "", model.AreaId
                                                   , model.AddressStreet ?? "", model.AddressBuilding ?? "", model.AddressFlat ?? "", model.Phone ?? ""
                                                   , model.ChangeRemarks ?? "", model.ArchiveId, model.BudgetType ?? "");

                return Json(new {Success = true,});
            }
            catch (Exception ex)
            {
                return Json(new {Success = false, Message = ex.Message,});
            }
        }

        [Authorize]
        [HttpPost]
        public ActionResult VisaApprove(GiveVisaModel model)
        {
            new ContractsProvider().VisaApprove(model.ChangeId, Auth.User.UserId, model.Subcategory);
            return Json(new { Success = true, });
        }

        [Authorize]
        [HttpPost]
        public ActionResult VisaDecline(GiveVisaModel model)
        {
            new ContractsProvider().VisaApprove(model.ChangeId, -Auth.User.UserId, model.Subcategory);
            return Json(new { Success = true, });
        }

        [Authorize]
        [HttpPost]
        public ActionResult ChangeParametersAjax(ChangeContractParametersAjaxModel model)
        {
            try
            {
                new ContractsProvider().ChangeParameters(Auth.User.UserId, model.ContractId, model.PeopleRegistered,
                                                           Misc.ToDouble(model.FixedConsumption), model.ChangeRemarks ?? "", model.HasSewage == "1", Misc.ToDouble(model.Allowance), model.AllowanceReason ?? "", Misc.ToDouble(model.FixedConsumptionSewage));

                return Json(new {Success = true,});
            }
            catch (Exception ex)
            {
                return Json(new {Success = false, Message = ex.Message});
            }
        }

        [Authorize]
        [HttpPost]
        public ActionResult AddMeterAjax(AddMeterAjaxModel model)
        {
            try
            {
                var res = new ContractsProvider().AddMeter(Auth.User.UserId, model.ContractId, model.SerialNumber ?? "", Misc.ToDouble(model.Value), model.ChangeRemarks ?? "");
                return Json(res);
            }
            catch (Exception ex)
            {
                return Json(new {Success = false, ex.Message});
            }
        }

        [Authorize]
        [HttpPost]
        public ActionResult AddTariffOptionAjax(AddTariffOptionAjaxModel model)
        {
            try
            {
                var res = new ContractsProvider().AddTariffOption(Auth.User.UserId, model.ContractId, model.SemanticId, Misc.ToDouble(model.Value), model.ChangeRemarks ?? "", model.Sewage);
                return Json(res);
            }
            catch (Exception ex)
            {
                return Json(new {Success = false, ex.Message,});
            }
        }

        [Authorize]
        [HttpPost]
        public ActionResult ChangeTariffOptionValueAjax(ChangeTariffOptionValueAjaxModel model)
        {
            try
            {
                new ContractsProvider().ChangeTariffOptionValue(Auth.User.UserId, model.TariffOptionId, Misc.ToDouble(model.Value), model.ChangeRemarks ?? "", model.Sewage);
                return Json(new {Success = true, Message = "", });
            }
            catch (Exception ex)
            {
                return Json(new {Success = false, ex.Message,});
            }
        }

        [Authorize]
        [HttpPost]
        public ActionResult RegisterTariffOptionActionAjax(RegisterTariffOptionActionAjaxModel model)
        {
            try
            {
                new ContractsProvider().RegisterTariffOptionAction(Auth.User.UserId, model.TariffOptionId, model.Action == "enable", model.ChangeRemarks ?? "");
                return Json(new {Success = true, Message = "",});
            }
            catch (Exception ex)
            {
                return Json(new {Success = false, ex.Message,});
            }
        }

        [Authorize]
        [HttpPost]
        public ActionResult RegiserConractActionAjax(RegiserConractActionAjaxModel model)
        {
            try
            {
                new ContractsProvider().RegisterContractAction(Auth.User.UserId, model.ContractId, model.Action == "enable", model.ChangeRemarks ?? "");
                return Json(new {Success = true, Message = "",});
            }
            catch (Exception ex)
            {
                return Json(new {Success = false, ex.Message,});
            }
        }

        [Authorize]
        [HttpPost]
        public ActionResult SpecialTransactionAjax(SpecialTransactionAjaxModel model)
        {
            try
            {
                new ContractsProvider().SpecialTransaction(Auth.User.UserId, model.ContractId, model.SubagentId,
                                                           model.IncreaseDebt == "1",
                                                           Misc.ToDouble(model.Amount), model.Remarks ?? "");

                return Json(new {Success = true, Message = "",});
            }
            catch (Exception ex)
            {
                return Json(new {Success = false, Message = ex.Message,});
            }
        }

        [Authorize]
        [HttpPost]
        public ActionResult MeterChangeAjax(MeterChangeAjaxModel model)
        {
            try
            {
                new ContractsProvider().MeterChange(Auth.User.UserId, model.MeterId, model.SerialNumber ?? "", model.ChangeRemarks ?? "");
                return Json(new {Success = true, Message = "",});
            }
            catch (Exception ex)
            {
                return Json(new {Success = false, Message = ex.Message,});
            }
        }

        [Authorize]
        [HttpPost]
        public ActionResult MeterActionAjax(MeterActionAjaxModel model)
        {
            try
            {
                new ContractsProvider().MeterAction(Auth.User.UserId, model.MeterId, model.Enabled > 0, model.ChangeRemarks ?? "");
                return Json(new {Success = true, Message = "",});
            }
            catch (Exception ex)
            {
                return Json(new {Success = false, Message = ex.Message,});
            }
        }

        [Authorize, HttpPost]
        public ActionResult ChangeRegistrationDebtAjax(ChangeRegistrationDebtAjaxModel model)
        {
            try
            {
                new ContractsProvider().ChangeRegistrationDebt(model.ContractId, Misc.ToDouble(model.Debt));

                return Json(true, "");
            }
            catch (Exception ex)
            {
                return Json(false, ex.Message);
            }
        }

        [Authorize]
        public ActionResult Statement(int contractId, int startPeriodId = -1, int endPeriodId = -1)
        {
            return View(new ContractsProvider().GetStatement(contractId, startPeriodId, endPeriodId));
        }

        [Authorize]
        public ActionResult PreviousBills(int contractId, int startPeriodId = -1, int endPeriodId = -1)
        {
            return View(new BillsProvider().GetPreviousBills(contractId, startPeriodId, endPeriodId));
        }

        [Authorize]
        public ActionResult BillStatement(int contractId)
        {
            return View(new ContractsProvider().GetContract(contractId));
        }

        [Authorize]
        public ActionResult ChangeTariffAjax(ChangeTariffAjaxModel model)
        {
            try
            {
                new ContractsProvider().ChangeTariff(Auth.User.UserId, model.ContractId, model.Tariff, model.Remarks ?? "");
                return Json(new {Success = true,});
            }
            catch (Exception ex)
            {
                return Json(new {Success = false, ex.Message,});
            }
        }
    }
}
