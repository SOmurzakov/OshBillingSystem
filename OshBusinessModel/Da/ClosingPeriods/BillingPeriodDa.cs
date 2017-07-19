using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OshBusinessModel.Da.ClosingPeriods
{
    public class BillingPeriodDa
    {
        public int BillingPeriodId { get; set; }
        public string Name { get; set; }

        public double StartBalance { get; set; }
        public double ContractsRegistrationDebts { get; set; }
        public double BilledAmount { get; set; }
        public double PayedAmount { get; set; }
        public double EndBalance { get; set; }

    }
}
