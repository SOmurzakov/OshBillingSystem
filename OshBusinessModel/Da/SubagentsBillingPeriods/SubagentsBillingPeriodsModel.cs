using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OshBusinessModel.Da.SubagentsBillingPeriods
{
    public class SubagentsBillingPeriodsModel
    {
        public int CurrentBillingPeriodId { get; set; }
        public string CurrentBillingPeriodName { get; set; }

        public BillingPeriodDa[] Periods { get; set; }
        public SubagentDa[] Subagents { get; set; }
    }
}
