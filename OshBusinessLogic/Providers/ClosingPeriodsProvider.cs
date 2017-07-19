using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using OshBusinessModel.Da.ClosingPeriods;
using OshBusinessModel.Da.Director;

namespace OshBusinessLogic.Providers
{
    public class ClosingPeriodsProvider
    {
        public BillingPeriodDa[] GetClosingPeriods()
        {
            return NativeSql.Exec("billing_getClosingPeriodsDictionary").Rows<BillingPeriodDa>();
        }
    }
}
