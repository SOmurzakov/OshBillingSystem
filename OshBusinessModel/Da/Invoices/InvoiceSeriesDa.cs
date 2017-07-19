using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OshBusinessModel.Da.Invoices
{
    public class InvoiceSeriesDa
    {
        public int Id { get; set; }
        public string SeriesNo { get; set; }
        public int StartId { get; set; }
        public int SeriesLength { get; set; }
        public int AlreadyIssued { get; set; }

        public int LastId { get { return StartId + SeriesLength - 1; } }
        public int CurrentId { get { return StartId + AlreadyIssued; } }
        public int Left { get { return SeriesLength - AlreadyIssued; } }
    }
}
