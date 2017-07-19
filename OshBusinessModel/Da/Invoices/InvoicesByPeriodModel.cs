using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using OshBusinessModel.Da.SubagentsBillingPeriods;

namespace OshBusinessModel.Da.Invoices
{
    public class InvoicesByPeriodModel
    {
        public int StartPeriodId { get; set; }
        public int EndPeriodId { get; set; }

        public DateTime StartPeriodDate { get; set; }
        public DateTime EndPeriodDate { get; set; }
        public BillingPeriodDa[] BillingPeriods { get; set; }
        public InvoicesByPeriodDa[] Invoices { get; set; }


        public double TotalAmountWithoutNds
        {
            get { return Invoices.Sum(invoice => invoice.AmountWithoutNds); }
        }
        public double TotalAmountNds
        {
            get { return Invoices.Sum(invoice => invoice.AmountNds); }
        }
        public double TotalAmountAllAfterTaxes
        {
            get { return Invoices.Sum(invoice => invoice.AmountAllAfterTaxes); }
        }
    }
}
