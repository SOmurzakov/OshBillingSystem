using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using OshBusinessLogic.Providers;
using OshChannel.Helpers;

namespace OshChannel.Controllers
{
    public class DirectorController : Controller
    {

        [Authorize]
        public ActionResult Index()
        {
            return View(new DirectorProvider().GetIndexModel());
        }

        [Authorize]
        public ActionResult CloseMonth()
        {
            return View(new ClosingPeriodsProvider().GetClosingPeriods());
        }

        [Authorize]
        [HttpPost]
        public ActionResult ClosePeriodAjax()
        {
            try
            {
                var result = new BillsProvider().ClosePeriod(Auth.User.UserId);
                return Json(result);
            }
            catch (Exception ex)
            {
                return Json(new {Success = false, ex.Message,});
            }
        }

        [Authorize]
        public ActionResult VisaRequired()
        {
            return View(new DirectorProvider().GetVisaRequiredItems());
        }
    }
}
