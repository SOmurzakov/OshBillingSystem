using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using OshBusinessLogic.Providers;
using OshChannel.Models;
using OshChannel.Helpers;

namespace OshChannel.Controllers
{
    public class InvoicesController : ControllerExtended
    {

        [Authorize]
        public ActionResult Index()
        {
            return View(new InvoicesProvider().GetInvoiceSeriesDictionary());
        }

        [Authorize, HttpPost]
        public ActionResult EditSeriesAjax(EditSeriesAjaxModel model)
        {
            try
            {
                new InvoicesProvider().EditSeries(Auth.User.UserId, model.Id, model.SeriesNo, model.StartId, model.Length);
                return Json(true, "");
            }
            catch (Exception ex)
            {
                return Json(false, ex.Message);
            }
        }

        [Authorize]
        public ActionResult InvoicesByPeriod(int startPeriodId = -1, int endPeriodId = -1)
        {
            return View(new InvoicesProvider().GetInvoicesByPeriod(startPeriodId, endPeriodId));
        }

        [Authorize]
        [HttpPost]
        public JsonResult ChangeInvoiceNumber(ChangeInvoiceNumberModel model)
        {
            try
            {
                new InvoicesProvider().ChangeInvoiceNumber(model.Id, model.Number);
                return Json(true, "");
            }
            catch (Exception ex)
            {
                return Json(false, ex.Message);
            }
        }
    }
}
