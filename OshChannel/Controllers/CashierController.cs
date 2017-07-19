using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OshChannel.Controllers
{
    public class CashierController : Controller
    {

        [Authorize]
        public ActionResult Index()
        {
            return View();
        }

    }
}
