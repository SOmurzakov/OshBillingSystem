using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using OshBusinessModel.Da.SubagentsBillingPeriods;

namespace OshBusinessModel.Da.Accountant
{
    public class SubscriberReconciliationReport
    {

        public int SubscriberId { get; set; }
        public string SubscriberName { get; set; }
        public int StartPeriodId { get; set; }
        public int EndPeriodId { get; set; }
        public double Debt { get; set; }

        public BillingPeriodDa[] BillingPeriods { get; set; }
        public SubscriberReconciliationBilingPeriodDa[] Bills { get; set; }

    }
}
