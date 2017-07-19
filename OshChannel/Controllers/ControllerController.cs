using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using OshBusinessLogic.Providers;
using OshChannel.Helpers;

namespace OshChannel.Controllers
{
    public class ControllerController : Controller
    {

        [Authorize]
        public ActionResult Index()
        {
            return View();
        }

        [Authorize]
        public ActionResult RootingsAreas()
        {
            return View(new RootingsProvider().GetRootingsAreas(Auth.User.UserId));
        }

        [Authorize]
        public ActionResult RootingsStreets(int userId=-1, int areaId=-1)
        {
            return View(new RootingsProvider().GetRootingsStreets(userId, areaId));
        }

        [Authorize]
        public ActionResult RootingsGetBuildings(int areaId, string street)
        {
            return View(new RootingsProvider().GetRootingsBuildings(areaId, street));
        }

        [Authorize]
        public ActionResult RootingsGetContracts(int areaId, string street, string building = "")
        {
            return View(new RootingsProvider().GetRootingsContracts(areaId, street, building));
        }

        [Authorize]

        public JsonResult RootingsChangeArea(int OldAreaId, int NewAreaId, string Street, string Building)
        {
            try
            {
                new RootingsProvider().RootingsChangeArea(OldAreaId, NewAreaId, Street, Building);
                return Json(new { Success = true, });
            }
            catch (Exception)
            {
                return Json(new { Message = "Произошла ошибка при попытке изменения участка", });
            }
        }
    }
}
