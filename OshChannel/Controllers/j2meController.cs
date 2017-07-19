using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using OshBusinessModel.J2MeDb.Dto;
using OshBusinessModel.J2MeDb.Requests;
using OshBusinessModel.J2MeDb.Responses;
using OshBusinessLogic;
using OshBusinessLogic.Helpers;

namespace OshChannel.Controllers
{
    public class j2meController : Controller
    {

        [HttpPost]
        public ActionResult Login(LoginRequest loginRequest)
        {
            var loginResponse = NativeSql.Exec(
                "j2me_loginAndReturnSession", 
                new
                    {
                        login = loginRequest.login, password = loginRequest.password,
                    }).OneRow<LoginResponse>();

            return Json(loginResponse);
        }

        [HttpPost]
        public ActionResult GetRootingsArrayEnclosed(GetRootingsRequest getRootingsRequest)
        {
            var getRootingsResponse = NativeSql.Exec("j2me_getRootings", new {session = getRootingsRequest.session,}).Rows<RootingDto>();

            GetRootingsResponseArrayEmbedded embedded = new GetRootingsResponseArrayEmbedded() { array = getRootingsResponse, };
            return Json(embedded);
        }

        [HttpPost]
        public ActionResult GetRootingDetails(GetRootingDetailsRequest request)
        {
            var tables = NativeSql.ExecMultiple("j2me_getRootingDetails", new {session = request.session, rootingId = request.rootingId,});

            GetRootingDetailsResponse response = new GetRootingDetailsResponse();

            if (tables.Length >= 2)
            {
                response = tables[0].OneRow<GetRootingDetailsResponse>();
                var meters = tables[1].Rows<MeterDtoDa>();

                response.meters = meters.Select(m => new MeterDto() {meterId = m.meterId, value = Misc.ToString(m.value),}).ToArray();
            }

            return Json(response);
        }

        [HttpPost]
        public ActionResult GetCloseRootingReasons(GetCloseRootingReasonsRequest request)
        {
            var reasons = NativeSql.Exec("j2me_getCloseRootingReasons", new {session = request.session, rootingId = request.rootingId,}).Rows<CloseReasonDto>();
            var response = new GetCloseRootingResponse() {reasons = reasons,};

            return Json(response);
        }

        [HttpPost]
        public ActionResult CloseRooting(CloseRootingRequest request)
        {
            NativeSql.Exec("j2me_closeRooting", new {session = request.session, rootingId = request.rootingId, reasonId = request.reasonId,});

            CloseRootingResponse response = new CloseRootingResponse() { ok = true, message = "" };

            return Json(response);
        }

        [HttpPost]
        public ActionResult RegisterPayment(RegisterPaymentRequest request)
        {
            if (request.amount > 0)
            {
                NativeSql.Exec("j2me_registePayment", new {session = request.session, rootingId = request.rootingId, amount = request.amount,});
            }

            RegisterPaymentResponse response = new RegisterPaymentResponse() { ok = true, message = "", };

            return Json(response);
        }

        [HttpPost]
        public ActionResult SetMetersValues(SetMetersValuesRequest request)
        {
            SetMetersValuesResponse response;

            if (request.meters != null && request.meters.Length > 0)
            {
                var meters = request.meters.Select(m => new MeterDtoDa() {meterId = m.meterId, value = Misc.ToDouble(m.value),}).ToArray();

                response =
                    NativeSql.Exec("j2me_setMetersValues",
                                   new {session = request.session, rootingId = request.rootingId, meters,})
                        .OneRow<SetMetersValuesResponse>();
            }
            else
            {
                response = new SetMetersValuesResponse() { ok = false, message = "Не верные значения счетчиков", };
            }

            return Json(response);
        }

    }
}
