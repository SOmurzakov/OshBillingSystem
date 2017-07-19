using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using OshBusinessModel.Da.Bills;
using System.Data;
using OshBusinessModel.Da.ClosingPeriods;
using OshBusinessModel.Da.Invoices;
using OshBusinessModel.Da.Controller;
using OshBusinessModel.Da.Areas;

namespace OshBusinessLogic.Providers
{
    public class BillsProvider
    {
        public Bill ComposeBill(DataTable[] tables, int offset)
        {
            BillPeriodDa billPeriod = tables[0 + offset].OneRow<BillPeriodDa>();

            var res = billPeriod == null
                       ? null
                       : new Bill()
                             {
                                 BillDetails = tables[1 + offset].OneRow<BillDa>(),
                                 Meters = tables[2 + offset].Rows<BillMeterDa>(),
                                 Options = tables[3 + offset].Rows<BillTariffOptionDa>(),
                                 ContractDetails = tables[4 + offset].OneRow<BillContractDetailsDa>(),
                             };

            return res;
        }

        public ClosePeriodResultDa ClosePeriod(int userId)
        {
            return NativeSql.Exec("billing_closeNextPeriod", new {userId, }).OneRow<ClosePeriodResultDa>();
        }

        public GetBillsForPrintingModel GetBillsForPrinting(int periodId, int controllerId, int areaId, string street)
        {
            var tables = NativeSql.ExecMultiple("billing_printBills", new {periodId, controllerId, areaId, street});

            GetBillsForPrintingModel model = new GetBillsForPrintingModel() {PeriodId = periodId, ControllerId = controllerId, AreaId = areaId};

            if (tables.Length <= 1)
            {
                return null;
            }
            
            model.BillingPeriods = tables[1].Rows<OshBusinessModel.Da.SubagentsBillingPeriods.BillingPeriodDa>();
            model.Controllers = tables[2].Rows<ControllerShortInfoDa>();
            model.Areas = tables[3].Rows<AreasShortInfoDa>();

            model.Bills = ComposeBills(tables, 5);

            return model;
        }

        public GetBillsForPrintingModel GetBillsForPrintingByAddress(int periodId, string street, bool allBuildings, ShortBuildingDa[] buildings, int userId)
        {
            var tables = NativeSql.ExecMultiple("billing_printBillsByAddress", new {periodId, street, allBuildings, buildings, userId});

            var model = new GetBillsForPrintingModel {PeriodId = periodId, };

            if (tables.Length <= 1)
            {
                return null;
            }

            model.BillingPeriods = tables[1].Rows<OshBusinessModel.Da.SubagentsBillingPeriods.BillingPeriodDa>();
            model.Streets = tables[2].Rows<ShortStreetDa>().Select(s => s.AddressStreet).ToArray();

            if (tables.Length > 3)
            {
                model.Bills = ComposeBills(tables, 3);
            }

            return model;
        }

        public GetInvoicesForPrintingModel GetInvoicesForPrinting(int periodId)
        {
            var tables = NativeSql.ExecMultiple("billing_printInvoices", new {periodId});

            if (tables.Length <= 1)
            {
                return null;
            }

            GetInvoicesForPrintingModel model = new GetInvoicesForPrintingModel() {PeriodId = periodId};
            model.BillingPeriods = tables[1].Rows<OshBusinessModel.Da.SubagentsBillingPeriods.BillingPeriodDa>();
            model.Invoices = tables[2].Rows<InvoiceDa>();

            var invoiceContracts = tables[3].Rows<InvoiceContractDa>();
            foreach (var invoice in model.Invoices)
            {
                invoice.Contracts = invoiceContracts.Where(ic => ic.SubscriberId == invoice.SubscriberId).ToArray();
            }

            return model;
        }

        public Bill[] ComposeBills(DataTable[] tables, int offset)
        {
            var billDetails = tables[offset + 0].Rows<BillDa>();
            var meters = tables[offset + 1].Rows<BillMeterDa>();
            var options = tables[offset + 2].Rows<BillTariffOptionDa>();
            var contractDetails = tables[offset + 3].Rows<BillContractDetailsDa>();

            return billDetails.Select(bd =>
                                      new Bill()
                                          {
                                              BillDetails = bd,
                                              Meters = meters.Where(m => m.BillId == bd.BillId).ToArray(),
                                              Options = options.Where(o => o.BillId == bd.BillId).ToArray(),
                                              ContractDetails =
                                                  contractDetails.FirstOrDefault(
                                                      cd => cd.ContractId == bd.ContractId),
                                          }).ToArray();
        }

        public PreviousBillsModel GetPreviousBills(int contractId, int startPeriodId, int endPeriodId)
        {
            var tables = NativeSql.ExecMultiple("billing_getPreviousBills", new { contractId, startPeriodId, endPeriodId });

            var model = tables[0].OneRow<PreviousBillsModel>();

            if (tables.Length <= 1 || model == null)
            {
                return null;
            }

            model.BillingPeriods = tables[1].Rows<OshBusinessModel.Da.SubagentsBillingPeriods.BillingPeriodDa>();

            model.Bills = ComposeBills(tables, 2);

            return model;
        }
    }
}
