using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using OshBusinessLogic.Providers;
using OshChannel.Models;

namespace OshChannel.Controllers
{
    public class AreasController : Controller
    {
        [Authorize]
        public ActionResult Index()
        {
            return View(new AreasProvider().GetAreasDictionary());
        }

        [Authorize]
        public ActionResult AreasControllers()
        {
            return View(new AreasProvider().GetAreasDictionary());
        }

        [Authorize]
        public ActionResult AreasHouses()
        {
            return View(new AreasProvider().GetAreasHouses());
        }

        [Authorize]
        [HttpPost]
        public ActionResult CreateAreaAjax(CreateAreaAjaxModel model)
        {
            if (model.AreaId > 0)
            {
                new AreasProvider().EditArea(model.AreaId, model.AreaName, model.Remarks ?? "", model.ControllerId);
            }
            else
            {
                new AreasProvider().CreateArea(model.AreaName, model.Remarks ?? "", model.ControllerId);
            }

            return Json(new {Success = true, Message = "",});
        }

        [Authorize]
        [HttpPost]
        public ActionResult SaveAreasControllersAjax(SaveAreasControllersAjaxModel model)
        {
            try
            {
                new AreasProvider().SaveAreasControllers(model.Areas);
                return Json(new {Success = true, Message = "",});
            }
            catch (Exception ex)
            {
                return Json(new {Success = false, ex.Message,});
            }
        }

        [Authorize]
        [HttpPost]
        public ActionResult SaveAreasHousesAjax(SaveAreasHousesAjaxModel model)
        {
            try
            {
                new AreasProvider().SaveAreasHouses(model.Houses);
                return Json(new {Success = true, Message = "",});
            }
            catch (Exception ex)
            {
                return Json(new {Success = false, ex.Message,});
            }
        }
    }
}