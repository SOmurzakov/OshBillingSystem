using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OshChannel.Controllers
{
    public class ControllerExtended : Controller
    {
        public JsonResult Json(bool success, string message)
        {
            return Json(new { Success = success, Message = message, });
        }
    }
}