using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OshBusinessModel.Da.Invoices
{
    public class InvoicesByPeriodDa
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public int InvoiceNumber { get; set; }
        public string SeriesNo { get; set; }
        public string Name { get; set; }
        public string Inn { get; set; }
        public string ContractUgknsCode { get; set; }
        public double AmountWithoutNds { get; set; }
        public double AmountNds { get; set; }
        public double AmountAllAfterTaxes { get; set; }
    }
}
