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
    public class SettingsController : Controller
    {

        [Authorize]
        public ActionResult Index()
        {
            return View(new SettingsProvider().GetSetings());
        }

        [Authorize]
        public ActionResult Details(string key)
        {
            return View(new SettingsProvider().GetSettingsDetails(key));
        }

        [Authorize]
        public ActionResult SetNewValue(SetNewValueModel model)
        {
            bool res = new SettingsProvider().SetNewValue(model.Key, model.Value, Auth.User.UserId);
            return Json(new {Success = res,});
        }

        [Authorize]
        public ActionResult VisaApprove(GiveVisaModel model)
        {
            new SettingsProvider().VisaApprove(model.ChangeId, Auth.User.UserId);
            return Json(new {Success = true,});
        }

        [Authorize]
        public ActionResult VisaDecline(GiveVisaModel model)
        {
            new SettingsProvider().VisaApprove(model.ChangeId, -Auth.User.UserId);
            return Json(new {Success = true,});
        }

    }
}
