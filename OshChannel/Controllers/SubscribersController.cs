using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using OshBusinessLogic.Helpers;
using OshBusinessLogic.Providers;
using OshBusinessModel.Da.Subscribers;
using OshChannel.Helpers;
using OshChannel.Models;

namespace OshChannel.Controllers
{
    public class SubscribersController : ControllerExtended
    {

        [Authorize]
        public ActionResult Show(int subscriberId)
        {
            return View(new SubscribersProvider().GetSubscriberDetails(subscriberId));
        }

        [Authorize]
        public ActionResult Dictionary(string type = null, int itemsPerPage = 100, int pageNumber = 1, string firstLetter = "а")
        {
            return View(new SubscribersProvider().GetSubscribersDictionary(type, itemsPerPage, pageNumber, firstLetter));
        }

        [Authorize]
        [HttpPost]
        public ActionResult ChangeInfoAjax(SubscriberChangeInfoAjaxModel model)
        {
            try
            {
                new SubscribersProvider().ChangeInfo(Auth.User.UserId, model.SubscriberId, model.Name ?? "", model.PassportNumber ?? "",
                                                     model.PassportWhere ?? "", Misc.ToDateTime(model.PassportDate), model.AddressStreet ?? "",
                                                     model.AddressBuilding ?? "", model.AddressFlat ?? "", model.Phone ?? "", model.Inn ?? "",
                                                     model.Ugkns ?? "", model.Mfo ?? "", model.Invoice > 0, model.ChangeRemarks ?? "",
                                                     model.UgknsName ?? "", model.BankCode ?? "", model.BankName ?? "", model.BankAccount ?? "");
                return Json(new {Success = true,});
            }
            catch (Exception ex)
            {
                return Json(new { Success = false, Message = ex.Message });
            }
        }

        [Authorize]
        public ActionResult VisaApprove(GiveVisaModel model)
        {
            new SubscribersProvider().VisaApprove(model.ChangeId, Auth.User.UserId);
            return Json(new { Success = true, });
        }

        [Authorize]
        public ActionResult VisaDecline(GiveVisaModel model)
        {
            new SubscribersProvider().VisaApprove(model.ChangeId, -Auth.User.UserId);
            return Json(new { Success = true, });
        }

        [Authorize, HttpPost]
        public ActionResult ClosePeriodAjax(int subscriberId)
        {
            try
            {
                new SubscribersProvider().ClosePeriod(Auth.User.UserId, subscriberId);
                return Json(true, "");
            }
            catch (Exception ex)
            {
                return Json(false, ex.Message);
            }
        }

        [Authorize, HttpPost]
        public ActionResult CancelClosePeriodAjax(int subscriberId)
        {
            try
            {
                new SubscribersProvider().CancelClosePeriod(Auth.User.UserId, subscriberId);
                return Json(true, "");
            }
            catch (Exception ex)
            {
                return Json(false, ex.Message);
            }
        }

        [Authorize]
        public ActionResult Invoice(int subscriberId)
        {
            return View(new BillingProvider().GetInvoiceForSubscriber(subscriberId));
        }

    }
}
