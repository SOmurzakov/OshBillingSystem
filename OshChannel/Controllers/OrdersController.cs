using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using OshChannel.Models;
using OshBusinessLogic.Providers;
using OshChannel.Helpers;
using System.Threading;

namespace OshChannel.Controllers
{
    public class OrdersController : Controller
    {

        [Authorize]
        [HttpPost]
        public ActionResult CloseMonth(CloseMonthModel model)
        {
            int userId = Auth.User.UserId;
            new Thread(() => new OrdersProvider().CloseMonth(userId)) {Name = "Closing month"}.Start();
            Thread.Sleep(1*1000);

            object res = new {Success = true,};
            return Json(res);
        }

        [Authorize]
        [HttpPost]
        public ActionResult CreateOrder(CloseMonthModel model)
        {
            int userId = Auth.User.UserId;
            new Thread(() => new OrdersProvider().CreateOrder(userId)) { Name = "Creating order" }.Start();
            Thread.Sleep(1*1000);

            object res = new { Success = true, };
            return Json(res);
        }

    }
}
