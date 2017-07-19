using System;
using OshBusinessModel.Da;
using OshBusinessModel.Da.Accountant;
using OshBusinessModel.Da.FundRaisingPlan;
using OshBusinessModel.Da.ReportByControllers;
using OshBusinessModel.Da.SubagentsBillingPeriods;

namespace OshBusinessLogic.Providers
{
    public class AccountantProvider
    {
        public ReconciliationReport GetReconciliationReport(DateTime dateStart, DateTime dateEnd)
        {
            dateStart = dateStart.Date;
            dateEnd = dateEnd.Date;
            var report = new ReconciliationReport() {DateStart = dateStart, DateEnd = dateEnd};
            report.Report = NativeSql.Exec("accountant_getReconciliationReport", new {dateStart, dateEnd,}).Rows<ReconciliationReportItemDa>();
            return report;
        }

        public ReconciliationByControllersReport GetReconciliationByControllersReport(DateTime dateStart, DateTime dateEnd)
        {
            var tables = NativeSql.ExecMultiple("accountant_getReconciliationReport_byControllers", new {dateStart, dateEnd});

            return
                new ReconciliationByControllersReport()
                {
                    DateStart = dateStart,
                    DateEnd = dateEnd,
                    Users = tables[0].Rows<RbcUserDa>(),
                    Subagents = tables[1].Rows<RbcSubagentDa>(),
                    Transactions = tables[2].Rows<RbcTransactionDa>(),
                };
        }

        public StatementFor1CDa GetStatementFor1C(DateTime date)
        {
            return NativeSql.Exec("accountant_getStatementFor1C", new {date.Date,}).OneRow<StatementFor1CDa>();
        }

        public ReconciliationByUserReport GetReconciliationByUserReport(DateTime dateStart, DateTime dateEnd, int userId, int subagentId)
        {
            dateStart = dateStart.Date;
            dateEnd = dateEnd.Date;

            return new ReconciliationByUserReport()
            {
                DateStart = dateStart,
                DateEnd = dateEnd,
                UserId = userId,
                SubagentId = subagentId,
                Transactions =
                    NativeSql.Exec("accountant_getReconciliationByUserReport", new {dateStart, dateEnd, userId, subagentId,}).Rows<TransactionDa>(),
            };
        }

        public ReportByControllersModel GetReportByControllers(int startPeriodId, int endPeriodId)
        {
            var tables = NativeSql.ExecMultiple("accountant_reportByControllers", new {startPeriodId, endPeriodId,});

            var model = tables[0].OneRow<ReportByControllersModel>();

            model.BillingPeriods = tables[1].Rows<BillingPeriodDa>();

            if (model.BillingPeriods == null || model.BillingPeriods.Length <= 0)
            {
                return null;
            }

            model.Report = tables[2].Rows<ReportByControllersDa>();

            return model;
        }

        public ReportByControllersModel GetReportByAreas(int startPeriodId, int endPeriodId)
        {
            var tables = NativeSql.ExecMultiple("accountant_reportByAreas", new {startPeriodId, endPeriodId,});

            var model = tables[0].OneRow<ReportByControllersModel>();

            model.BillingPeriods = tables[1].Rows<BillingPeriodDa>();

            if (model.BillingPeriods == null || model.BillingPeriods.Length <= 0)
            {
                return null;
            }

            model.Report = tables[2].Rows<ReportByControllersDa>();

            return model;
        }

        public ReportByDistrictsModel GetReportByDistricts(string districtName, int periodId)
        {
            var tables = NativeSql.ExecMultiple("accountant_reportByDistricts", new { districtName, periodId });

            var model = tables[0].OneRow<ReportByDistrictsModel>();

            model.BillingPeriods = tables[1].Rows<BillingPeriodDa>();

            if (model.BillingPeriods == null || model.BillingPeriods.Length <= 0)
            {
                return null;
            }

            model.DistrictNames = tables[2].Rows<DistrictNameDa>();
            model.Report = tables[3].Rows<ReportByDistrictsDa>();

            return model;
        }

        public ReportByControllersModel GetReportByStreets(int startPeriodId, int endPeriodId, int controllerId)
        {
            var tables = NativeSql.ExecMultiple("accountant_reportByStreets", new { startPeriodId, endPeriodId, controllerId });

            var model = tables[0].OneRow<ReportByControllersModel>();

            model.BillingPeriods = tables[1].Rows<BillingPeriodDa>();

            if (model.BillingPeriods == null || model.BillingPeriods.Length <= 0)
            {
                return null;
            }

            model.Controllers = tables[2].Rows<ControllerShortModel>();

            model.Report = tables[3].Rows<ReportByControllersDa>();

            return model;
        }

        public ReportByControllersModel GetReportByTariffs(int startPeriodId, int endPeriodId)
        {
            var tables = NativeSql.ExecMultiple("accountant_reportByTariffs", new {startPeriodId, endPeriodId,});

            var model = tables[0].OneRow<ReportByControllersModel>();

            model.BillingPeriods = tables[1].Rows<BillingPeriodDa>();

            if (model.BillingPeriods == null || model.BillingPeriods.Length <= 0)
            {
                return null;
            }

            model.Report = tables[2].Rows<ReportByControllersDa>();
            model.TariffOptions = tables[3].Rows<ReportByControllersDa>();
            

            return model;
        }

        public FundRaisingPlanModel GetFundRaisingPlan(int periodId)
        {
            var tables = NativeSql.ExecMultiple("accountant_fundRaisingPlan", new {periodId});

            var model = tables[0].OneRow<FundRaisingPlanModel>();

            if (model == null)
            {
                return null;
            }

            model.BillingPeriods = tables[1].Rows<BillingPeriodDa>();
            model.Controllers = tables[2].Rows<FundRaisingPlanDa>();

            return model;
        }

        public SubscriberReconciliationReport GetSubscriberReconciliation(int subscriberId, int startPeriodId, int endPeriodId)
        {
            var tables = NativeSql.ExecMultiple("accountant_subscriberReconciliation",
                new {subscriberId, startPeriodId, endPeriodId});

            var periods = tables[0].Rows<BillingPeriodDa>();

            if (periods == null || periods.Length == 0)
            {
                return null;
            }

            var model = tables[1].OneRow<SubscriberReconciliationReport>();

            if (model != null)
            {
                model.BillingPeriods = periods;
                model.Bills = tables[2].Rows<SubscriberReconciliationBilingPeriodDa>();
            }

            return model;
        }
    }


}