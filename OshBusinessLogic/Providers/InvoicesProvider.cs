using OshBusinessModel.Da.Invoices;
using OshBusinessModel.Da.SubagentsBillingPeriods;

namespace OshBusinessLogic.Providers
{
    public class InvoicesProvider
    {
        public InvoiceSeriesDa[] GetInvoiceSeriesDictionary()
        {
            return NativeSql.Exec("invoices_getSeries").Rows<InvoiceSeriesDa>();
        }

        public void EditSeries(int userId, int id, string seriesNo, int startId, int length)
        {
            NativeSql.Exec("invoices_edit", new {id, seriesNo, startId, length,});
        }

        public InvoicesByPeriodModel GetInvoicesByPeriod(int startPeriodId, int endPeriodId)
        {
            var tables = NativeSql.ExecMultiple("invoices_getByPeriod", new {startPeriodId, endPeriodId});

            var periods = tables[0].Rows<BillingPeriodDa>();

            if (periods == null || periods.Length == 0) return null;

            var invoices = tables[1].Rows<InvoicesByPeriodDa>();
            var model = tables[2].OneRow<InvoicesByPeriodModel>();

            model.StartPeriodId = startPeriodId;
            model.EndPeriodId = endPeriodId;
            model.BillingPeriods = periods;
            model.Invoices = invoices;

            return model;
        }

        public void ChangeInvoiceNumber(int id, int number)
        {
            NativeSql.Exec("invoices_changeInvoiceNumber", new {id, number});
        }
    }
}