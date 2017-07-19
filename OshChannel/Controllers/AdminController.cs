using System;
using System.Web.Mvc;
using OshBusinessLogic.Providers;
using OshChannel.Models;

namespace OshChannel.Controllers
{
    public class AdminController : Controller
    {
        [Authorize]
        public ActionResult Index()
        {
            return View();
        }

        [Authorize]
        public ActionResult Streets()
        {
            var streets = new StreetsProvider().GetAllStreets();
            return View(streets);
        }

        [Authorize]
        [HttpPost]
        public ActionResult RenameStreet(RenameStreetModel model)
        {
            try
            {
                new StreetsProvider().Rename(model.Street, model.NewName);
                return Json(new {Success = true, Message = "",});
            }
            catch (Exception ex)
            {
                return Json(new {Success = false, ex.Message});
            }
        }
    }
}