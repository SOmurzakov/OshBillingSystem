using System;
using System.Linq;
using OshBusinessModel.Da;
using OshBusinessModel.Da.Bills;
using OshBusinessModel.Da.BulkPayments;
using OshBusinessModel.Da.AllowanceReport;

namespace OshBusinessLogic.Providers
{
    public class CustomerCareProvider
    {
        public BuilkPaymentsModel GetStartInfoForBulkPayments()
        {
            var tables = NativeSql.ExecMultiple("customs_getInfoForBulkPayments");

            return new BuilkPaymentsModel()
            {
                SubagentsUsers = tables[0].Rows<ShortSubagentOrUserInfo>(),
                Streets = tables[1].Rows<StreetWrapper>().Select(sw => sw.Street).ToArray()
            };
        }

        public BulkPaymentContractInfoDa GetContractInfoByArchiveId(string keyValue, string searchCriteria)
        {
            var tables = NativeSql.ExecMultiple("customs_bulkPaymentGetContractInfo", new {keyValue, searchCriteria});
            var result = tables[0].OneRow<BulkPaymentContractInfoDa>();
            if (tables.Length > 1)
            {
                result.Options = tables[1].Rows<BkciOptionsDa>();
            }

            return result;
        }

        public ResultDa RegisterBulkPayments(int registeredUserId, int subagentId, int userId, DateTime date, bool useController, BulkPaymentDa[] payments)
        {
            return NativeSql.Exec("customs_bulkPayments", new {registeredUserId, subagentId, userId, date, useController, payments}).OneRow<ResultDa>();
        }

        public HasAllowanceReport GetHasAllowanceReport()
        {
            var tables = NativeSql.ExecMultiple("allowance_hasAllowanceReport");
            return new HasAllowanceReport {Controllers = tables[0].Rows<AllowanceReportControllerDa>(), Tariffs = tables[1].Rows<AllowanceReportTariffDa>(), Items = tables[2].Rows<AllowanceReportItemDa>()};
        }

        public WithoutAllowanceReport GetWithoutAllowanceReport()
        {
            var tables = NativeSql.ExecMultiple("allowance_withoutAllowanceReport");
            return new WithoutAllowanceReport
            {
                Controllers = tables[0].Rows<AllowanceReportControllerDa>(),
                Tariffs = tables[1].Rows<AllowanceReportTariffDa>(),
                TariffOptions = tables[2].Rows<AllowanceReportTariffOptionDa>(),
                Items = tables[3].Rows<AllowanceReportItemDa>(),
                ItemOptions = tables[4].Rows<AllowanceReportItemOptionDa>(),
            };
        }

        public string[] GetBuildings(string street)
        {
            return NativeSql.Exec("streets_getBuildings", new {street,}).Rows<ShortBuildingDa>().Select(b => b.AddressBuilding).ToArray();
        }

        public ShortControllerDa[] GetControllers(string street)
        {
            return NativeSql.Exec("streets_getControllers", new { street, }).Rows<ShortControllerDa>();
        }
    }
}