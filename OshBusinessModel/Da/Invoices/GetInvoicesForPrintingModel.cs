using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using OshBusinessModel.Da.SubagentsBillingPeriods;
using OshBusinessModel.Da.Controller;
using OshBusinessModel.Da.Areas;

namespace OshBusinessModel.Da.Invoices
{
    public class GetInvoicesForPrintingModel
    {
        public int PeriodId { get; set; }

        public BillingPeriodDa[] BillingPeriods { get; set; }

        public InvoiceDa[] Invoices { get; set; }
    }
}
