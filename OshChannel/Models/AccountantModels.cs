using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using OshBusinessModel.Da;

namespace OshChannel.Models
{
    public class ReconciliationTransactionsPartialModel
    {
        public DateTime DateStart { get; set; }
        public DateTime DateEnd { get; set; }
        public IEnumerable<ReconciliationReportItemDa> Transactions { get; set; }
    }
}