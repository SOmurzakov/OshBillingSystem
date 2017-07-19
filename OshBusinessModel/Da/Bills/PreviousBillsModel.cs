using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using OshBusinessModel.Da.SubagentsBillingPeriods;

namespace OshBusinessModel.Da.Bills
{
    public class PreviousBillsModel
    {
        public int ContractId { get; set; }
        public int StartPeriodId { get; set; }
        public int EndPeriodId { get; set; }

        public BillingPeriodDa[] BillingPeriods { get; set; }
        public Bill[] Bills { get; set; }
    }
}
