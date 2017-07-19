using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OshBusinessModel.Da.Accountant
{
    public class SubscriberReconciliationBilingPeriodDa
    {
        public int BillingPeriodId { get; set; }
        public string BillingPeriodName { get; set; }
        public double BilledAmount { get; set; }
        public double PayedAmount { get; set; }
    }
}
