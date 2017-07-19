using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using OshBusinessLogic.Providers;
using OshBusinessLogic.Helpers;

namespace OshChannel.Controllers
{
    public class AccountantController : Controller
    {

        [Authorize]
        public ActionResult Index()
        {
            return View();
        }

        [Authorize]
        public ActionResult Reconciliation(string dateStart = "", string dateEnd = "")
        {
            DateTime parsedDateStart = Misc.ToDateTime(dateStart) ?? DateTime.Today;
            DateTime parsedDateEnd = Misc.ToDateTime(dateEnd) ?? DateTime.Today;

            return View(new AccountantProvider().GetReconciliationReport(parsedDateStart, parsedDateEnd));
        }

        [Authorize]
        public ActionResult ReconciliationByControllers(string dateStart = "", string dateEnd = "")
        {
            DateTime parsedDateStart = Misc.ToDateTime(dateStart) ?? DateTime.Today;
            DateTime parsedDateEnd = Misc.ToDateTime(dateEnd) ?? DateTime.Today;

            return View(new AccountantProvider().GetReconciliationByControllersReport(parsedDateStart, parsedDateEnd));
        }

        [Authorize]
        public ActionResult Transactions(int userId, int subagentId, string dateStart = "", string dateEnd = "")
        {
            DateTime parsedDateStart = Misc.ToDateTime(dateStart) ?? DateTime.Today;
            DateTime parsedDateEnd = Misc.ToDateTime(dateEnd) ?? DateTime.Today;
            return View("ReconciliationByUser", new AccountantProvider().GetReconciliationByUserReport(parsedDateStart, parsedDateEnd, userId, subagentId));
        }

        [Authorize]
        public ActionResult StatementFor1C(DateTime date)
        {
            return View(new AccountantProvider().GetStatementFor1C(date));
        }

        [Authorize]
        public ActionResult Sync1C()
        {
            return View();
        }

        [Authorize]
        public ActionResult ReportByControllers(int startPeriodId = -1, int endPeriodId = -1)
        {
            return View(new AccountantProvider().GetReportByControllers(startPeriodId, endPeriodId));
        }

        [Authorize]
        public ActionResult ReportByAreas(int startPeriodId = -1, int endPeriodId = -1)
        {
            return View(new AccountantProvider().GetReportByAreas(startPeriodId, endPeriodId));
        }

        [Authorize]
        public ActionResult ReportByDistricts(string districtName="", int periodId = -1)
        {
            return View(new AccountantProvider().GetReportByDistricts(districtName, periodId));
        }

        [Authorize]
        public ActionResult ReportByStreets(int startPeriodId = -1, int endPeriodId = -1, int controllerId = -1)
        {
            return View(new AccountantProvider().GetReportByStreets(startPeriodId, endPeriodId, controllerId));
        }

        [Authorize]
        public ActionResult ReportByTariffs(int startPeriodId = -1, int endPeriodId = -1)
        {
            return View(new AccountantProvider().GetReportByTariffs(startPeriodId, endPeriodId));
        }

        [Authorize]
        public ActionResult FundRaisingPlan(int periodId = -1)
        {
            return View(new AccountantProvider().GetFundRaisingPlan(periodId));
        }

        [Authorize]
        public ActionResult SubscriberReconciliation(int subscriberId, int startPeriodId = -1, int endPeriodId = -1)
        {
            return View(new AccountantProvider().GetSubscriberReconciliation(subscriberId, startPeriodId, endPeriodId));
        }

    }
}
