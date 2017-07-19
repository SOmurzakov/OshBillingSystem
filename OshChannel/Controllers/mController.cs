using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using OshChannel.Helpers;
using OshChannel.Models;
using System.Web.Security;
using OshBusinessLogic.Providers;
using OshBusinessModel.Data;
using OshBusinessModel.Da.Meters;
using OshBusinessLogic.Helpers;

namespace OshChannel.Controllers
{
    public class mController : Controller
    {

        public ActionResult Index()
        {
            if (!Auth.Authenticated)
            {
                return RedirectToAction("Login", "m");
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
                    return RedirectToAction(userType.AspController);
                }
            }

            //return View();
        }

        public ActionResult Login()
        {
            return View();
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
                        return RedirectToAction(userType.AspController);
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

        [Authorize]
        public ActionResult Controller()
        {
            return View(new RootingsProvider().GetRootingsAreas(Auth.User.UserId));
        }

        [Authorize]
        public ActionResult ControllerRootingsStreets(int areaId)
        {
            return View(new RootingsProvider().GetRootingsStreets(Auth.User.UserId, areaId));
        }

        [Authorize]
        public ActionResult ControllerRootingsGetBuildings(int areaId, string street)
        {
            return View(new RootingsProvider().GetRootingsBuildings(areaId, street));
        }

        [Authorize]
        public ActionResult ControllerRootingsGetContracts(int areaId, string street, string building)
        {
            return View(new RootingsProvider().GetRootingsContracts(areaId, street, building));
        }

        [Authorize]
        public ActionResult Contract(int contractId)
        {
            return View(new ContractsProvider().ShowContractsMobile(contractId));
        }

        [Authorize]
        public ActionResult ContractMakePayment(int contractId, int amount)
        {
            return View(new OshBusinessModel.Da.Mobiles.MakePaymentModel() {ContractId = contractId, Amount = amount,});
        }

        [Authorize]
        [HttpPost]
        public ActionResult ContractMakePayment(OshBusinessModel.Da.Mobiles.MakePaymentModel model)
        {
            new ContractsProvider().MakePayment(model.ContractId, model.Amount, Auth.User.UserId, 0, Auth.User.UserId, "");
            return RedirectToAction("Contract", new {contractId = model.ContractId,});
        }

        [Authorize]
        public ActionResult ContractSetMetersValues(int contractId)
        {
            return View(new ContractsProvider().ShowContractsMobile(contractId));
        }

        [Authorize]
        [HttpPost]
        public ActionResult ContractSetMetersValues(int contractId, int[] meterid, string[] metervalue)
        {
            List<SetMetersValuesDa> values = new List<SetMetersValuesDa>();

            for (int i = 0; i < meterid.Length; i++)
            {
                values.Add(new SetMetersValuesDa() {MeterId = meterid[i], Value = Misc.ToDouble(metervalue[i])});
            }

            var res = new ContractsProvider().SetMetersValues(Auth.User.UserId, DateTime.Now, values.ToArray(), MeterReadingType.Regular.SemanticId);

            return RedirectToAction("Contract", new { contractId });
        }

    }
}
