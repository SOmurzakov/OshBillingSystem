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
    public class UsersController : Controller
    {

        [Authorize]
        public ActionResult Index()
        {
            return View(new UsersProvider().GetUsersDictionary());
        }

        [Authorize]
        public ActionResult Details(int userId)
        {
            return View(new UsersProvider().GetUserDetails(userId));
        }

        [Authorize]
        public ActionResult CreateUserAjax(CreateUserAjaxModel model)
        {
            var res = new UsersProvider().CreateUser(Auth.User.UserId, model.Login, model.Password, model.Role, model.Name ?? "", model.Passport ?? "", model.Address ?? "", model.Phone ?? "");
            return Json(new { Success = res.Success, Message = res.Message, });
        }

        [Authorize]
        public ActionResult UserChangeDetailsAjax(UserChangeDetailsAjaxModel model)
        {
            new UsersProvider().ChangeUserDetails(Auth.User.UserId, model.UserId, model.Name ?? "", model.Passport ?? "", model.Address ?? "", model.Phone ?? "");
            return Json(new {Success = true, Message = "", });
        }

        [Authorize]
        public ActionResult UserSetRoleAjax(UserSetRoleAjaxModel model)
        {
            new UsersProvider().SetRole(Auth.User.UserId, model.UserId, model.Role);
            return Json(new {Success = true, Message = "",});
        }

        [Authorize]
        public ActionResult UserChangePasswordAjax(UserChangePasswordAjaxModel model)
        {
            new UsersProvider().ChangePassword(Auth.User.UserId, model.UserId, model.Password);
            return Json(new {Success = true, Message = "",});
        }

        [Authorize]
        public ActionResult UserDisableAjax(UserDisableAjaxModel model)
        {
            new UsersProvider().Disable(Auth.User.UserId, model.UserId, model.Remarks);
            return Json(new { Success = true, Message = "", });
        }

        [Authorize]
        public ActionResult UserEnableAjax(UserEnableAjaxModel model)
        {
            new UsersProvider().Enable(Auth.User.UserId, model.UserId);
            return Json(new { Success = true, Message = "", });
        }
    }
}
