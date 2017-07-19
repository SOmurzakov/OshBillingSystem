using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using OshBusinessLogic.Providers;
using OshChannel.Models;
using OshChannel.Helpers;
using OshBusinessLogic.Helpers;

namespace OshChannel.Controllers
{
    public class SubagentsController : ControllerExtended
    {

        [Authorize]
        public ActionResult Index()
        {
            return View(new SubagentsProvider().GetSubagentsDictionary());
        }

        [Authorize]
        public ActionResult Transactions(int subagentId)
        {
            return View(new SubagentsProvider().GetTransactions(subagentId));
        }

        [Authorize]
        [HttpPost]
        public ActionResult CreateSubagentAjax(CreateSubagentAjaxModel model)
        {
            try
            {
                new SubagentsProvider().Create(model.Name ?? "", model.Remarks ?? "", model.HasBalance > 0, model.RightCurrentBalance);
                return Json(new {Success = true, Message = "",});
            }
            catch (Exception ex)
            {
                return Json(new {Success = false, ex.Message,});
            }
        }

        [Authorize]
        [HttpPost]
        public ActionResult RegisterPopupAjax(RegisterPopupAjaxModel model)
        {
            try
            {
                new SubagentsProvider().RegisterPopup(Auth.User.UserId, model.SubagentId, Misc.ToDouble(model.Amount), model.Remarks ?? "");
                return Json(new {Success = true, Message = "",});
            }
            catch (Exception ex)
            {
                return Json(new {Success = false, ex.Message,});
            }
        }

        [Authorize]
        public ActionResult SubagentsBillingPeriods(int periodId = -1)
        {
            return View(new SubagentsProvider().GetBillingPeriodsModel(periodId));
        }

        [Authorize, HttpPost]
        public ActionResult ChangeInfoAjax(ChangeInfoAjaxModel model)
        {
            try
            {
                new SubagentsProvider().ChangeInfo(model.Id, model.Name ?? "");

                return Json(true, "");
            }
            catch (Exception ex)
            {
                return Json(false, ex.Message);
            }
        }

/*
        [Authorize]
        [HttpPost]
        public ActionResult RegisterTransactionJson(RegisterTransactionModel model)
        {
            bool ok = new SubagentsProvider().RegisterTransaction(model.SubagentId, model.Amount, model.ContractId, Auth.User.UserId);
            object res = new { Success = ok, };
            return Json(res);
        }
*/

    }
}
