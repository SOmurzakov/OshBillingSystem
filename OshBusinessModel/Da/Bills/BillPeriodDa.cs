using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OshBusinessModel.Da.Bills
{
    public class BillPeriodDa
    {
        public int BillingPeriodId { get; set; }
        public string Name { get; set; }
        public DateTime PeriodEnd { get; set; }
    }
}
