using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using OshChannel.Models;
using OshBusinessLogic.Providers;
using System.Web.Security;
using OshChannel.Helpers;
using OshBusinessModel.Data;

namespace OshChannel.Controllers
{
    public class IndexController : Controller
    {
        //
        // GET: /Index/

        public ActionResult Index()
        {
            if (!Auth.Authenticated)
            {
                return View();
            }
            else
            {
                var userType = UserType.GetUserTypeById(Auth.User.Role);

                if (userType == UserType.Unknown)
                {
                    return RedirectToAction("Index", "Index");
                }
                else
                {
                    return RedirectToAction("Index", userType.AspController);
                }
            }
        }

        [HttpPost]
        public ActionResult Login(LoginModel model)
        {
            if (ModelState.IsValid)
            {
                string role = new UsersProvider().UserExistsAndReturnRole(model.Login, model.Password);
                if (!string.IsNullOrWhiteSpace(role))
                {
                    FormsAuthentication.SetAuthCookie(model.Login, false);

                    var userType = UserType.GetUserTypeById(role);

                    if (userType == UserType.Unknown)
                    {
                        return RedirectToAction("Index", "Index");
                    }
                    else
                    {
                        return RedirectToAction("Index", userType.AspController);
                    }
                }
                else
                {
                    ModelState.AddModelError("", "Пользователь не найден.");
                }
            }

            return RedirectToAction("Index");
        }

        [Authorize]
        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();

            return RedirectToAction("Index");
        }

    }
}
