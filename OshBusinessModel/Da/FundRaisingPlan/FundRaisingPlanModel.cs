using System.Linq;
using OshBusinessModel.Da.SubagentsBillingPeriods;

namespace OshBusinessModel.Da.FundRaisingPlan
{
    public class FundRaisingPlanModel
    {
        public int PeriodId { get; set; }
        public string PeriodName { get; set; }
        public double FundRaisingPlan { get; set; }
        public bool FundRaisingPlanIsPercent { get; set; }

        public BillingPeriodDa[] BillingPeriods { get; set; }
        public FundRaisingPlanDa[] Controllers { get; set; }

        public FundRaisingPlanDa Total
        {
            get
            {
                FundRaisingPlanDa total = new FundRaisingPlanDa();

                total.StartBalance = Controllers.Sum(c => c.StartBalance);
                total.BilledAmount = Controllers.Sum(c => c.BilledAmount);
                total.PlanAmount = Controllers.Sum(c => c.PlanAmount);
                total.RaisedAmount = Controllers.Sum(c => c.RaisedAmount);

                return total;
            }
        }
    }
}