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
    public class TariffsController : Controller
    {

        [Authorize]
        public ActionResult Index()
        {
            ViewBag.Title = "Действующие тарифы";
            return View(new TariffsProvider().GetTariffsDictionary());
        }

        [Authorize]
        public ActionResult Archive()
        {
            ViewBag.Title = "Архив тарифов";
            return View("Index", new TariffsProvider().GetTariffsArchiveDictionary());
        }
        
        [Authorize]
        public ActionResult Details(string tariff)
        {
            return View("Details", new TariffsProvider().GetDetails(tariff));
        }

        [Authorize]
        public ActionResult TariffOption(string option)
        {
            return View("TariffOption", new TariffsProvider().GetTariffOptionDetails(option));
        }

        [Authorize]
        public ActionResult ChangeTariffPriceAjax(ChangeTariffPriceAjaxModel model)
        {
            new TariffsProvider().ChangeTariffPrice(Auth.User.UserId, model.TariffId, model.TariffName,
                                                    Misc.ToDouble(model.LitersPerPersonPerDay),
                                                    Misc.ToDouble(model.WaterPricePerCubicMeter), 
                                                    Misc.ToDouble(model.SewagePricePerCubicMeter));
            return Json(new {Success = true, Message = "Тариф успешно изменен", });
        }

        [Authorize]
        public ActionResult ChangeTariffOptionPriceAjax(ChangeTariffOptionAjaxModel model)
        {
            new TariffsProvider().ChangeTariffOptionPrice(Auth.User.UserId, model.TariffOptionId, Misc.ToDouble(model.LitersPerDay));
            return Json(new { Success = true, Message = "", });
        }

    }
}
