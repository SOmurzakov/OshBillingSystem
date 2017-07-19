using System;
using System.Linq;
using System.Web.Mvc;
using OshBusinessLogic.Helpers;
using OshBusinessLogic.Providers;
using OshBusinessModel.Da.Bills;
using OshBusinessModel.Da.BulkPayments;
using OshChannel.Helpers;
using OshChannel.Models;

namespace OshChannel.Controllers
{
    public class CustomerCareController : ControllerExtended
    {
        [Authorize]
        public ActionResult Index()
        {
            //return View();
            return View(new CustomerCareProvider().GetStartInfoForBulkPayments());

        }

        [Authorize]
        public ActionResult Rootings(int periodId = -1, int controllerId = -1, int areaId = -1)
        {
            return View(new RootingsProvider().GetRootingsForController(periodId, controllerId, areaId));
        }

        [Authorize]
        public ActionResult PrintBills(int periodId = -1, int controllerId = -1, int areaId = -1, string street = "")
        {
            return View(new BillsProvider().GetBillsForPrinting(periodId, controllerId, areaId, street));
        }

        [Authorize]
        public ActionResult PrintBillsByAddress()
        {
            return View(new BillsProvider().GetBillsForPrintingByAddress(-1, null, false, new ShortBuildingDa[]{}, -1));
        }

        [Authorize]
        public ActionResult PrintInvoices(int periodId = -1)
        {
            return View(new BillsProvider().GetInvoicesForPrinting(periodId));
        }

        [Authorize]
        public ActionResult BulkPayments()
        {
            return View(new CustomerCareProvider().GetStartInfoForBulkPayments());
        }

        [Authorize, HttpPost]
        public ActionResult GetConctractInfoByArchiveIdAjax(GetContractInfoAjaxModel model)
        {
            try
            {
                return Json(new CustomerCareProvider().GetContractInfoByArchiveId(model.KeyValue, model.SearchCriteria));
            }
            catch (Exception)
            {
                return Json(new {Found = false,});
            }
        }

        [Authorize, HttpPost]
        public ActionResult BulkPaymentsAjax(BulkPaymentsAjaxModel model)
        {
            try
            {
                var date = Misc.ToDateTime(model.Date);
                if (date == null)
                {
                    date = DateTime.Today;
                }

                var useController = model.UseController > 0;

                var result =
                    new CustomerCareProvider()
                        .RegisterBulkPayments
                        (
                            Auth.User.UserId,
                            model.SubagentId,
                            model.UserId,
                            date.Value,
                            useController,
                            model.Payments.Select(
                                p =>
                                    new BulkPaymentDa()
                                    {
                                        ContractId = p.ContractId,
                                        ReceiptNo = p.ReceiptNo ?? "",
                                        Amount = Misc.ToDouble(p.Amount)
                                    }).ToArray());

                var redirectUrl = useController ? Url.Action("Index", "Index") : Url.Action("Transactions", "Accountant",
                    new
                    {
                        dateStart = date.Value.ToShortDateString(),
                        dateEnd = date.Value.ToShortDateString(),
                        userId = model.UserId,
                        subagentId = model.SubagentId
                    });

                return result.Success
                    ? Json(
                        new
                        {
                            Success = true,
                            Message = "",
                            RedirectUrl = redirectUrl
                        })
                    : Json(result);
            }
            catch (Exception ex)
            {
                return Json(false, ex.Message);
            }
        }

        [Authorize]
        public ActionResult HasAllowanceReport()
        {
            return View(new CustomerCareProvider().GetHasAllowanceReport());
        }

        [Authorize]
        public ActionResult WithoutAllowanceReport()
        {
            return View(new CustomerCareProvider().GetWithoutAllowanceReport());
        }

        [HttpPost, Authorize]
        public JsonResult GetBuildings(string street)
        {
            var buildings = new CustomerCareProvider().GetBuildings(street);
            var jsonResult = new JsonResult();
            jsonResult.Data = buildings;
            jsonResult.JsonRequestBehavior = JsonRequestBehavior.AllowGet;
            return jsonResult;
        }

        [HttpPost, Authorize]
        public JsonResult GetControllers(string street)
        {
            var controllers = new CustomerCareProvider().GetControllers(street);
            var jsonResult = new JsonResult();
            jsonResult.Data = controllers;
            jsonResult.JsonRequestBehavior = JsonRequestBehavior.AllowGet;
            return jsonResult;
        }

        [HttpPost, Authorize]
        public PartialViewResult GetBillsForAddress(GetBillsForAddressModel model)
        {
            var results = new BillsProvider().GetBillsForPrintingByAddress(
                model.PeriodId, 
                model.Street, 
                model.AllBuildings, 
                model.Buildings ?? new ShortBuildingDa[] {},
                model.ControllerId
                );
            return PartialView("PrintBillByAddressResultsPartial", results);
        }
    }
}