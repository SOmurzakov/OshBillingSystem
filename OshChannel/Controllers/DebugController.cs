using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using OshBusinessLogic.Providers;

namespace OshChannel.Controllers
{
    public class DebugController : Controller
    {
        [Authorize]
        public ActionResult Index()
        {
            return View();
        }

        [Authorize]
        [HttpPost]
        public ActionResult ClearBillingAjax()
        {
            try
            {
                new DebugProvider().ClearBilling();
                return Json(new {Success = true, Message = "",});
            }
            catch (Exception ex)
            {
                return Json(new {Success = false, ex.Message,});
            }
        }

    }
}
