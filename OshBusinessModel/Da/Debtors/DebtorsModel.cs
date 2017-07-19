using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using OshBusinessModel.Da.SubagentsBillingPeriods;

namespace OshBusinessModel.Da.Debtors
{
    public class DebtorsModel
    {
        public int Threshold { get; set; }
        public int StartPeriodId { get; set; }
        public int EndPeriodId { get; set; }

        public BillingPeriodDa[] BillingPeriods { get; set; }
        public DebtorDa[] Debtors { get; set; }
    }
}
