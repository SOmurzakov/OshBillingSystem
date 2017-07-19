using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OshBusinessModel.Da.FundRaisingPlan
{
    public class FundRaisingPlanDa
    {
        public int ControllerId { get; set; }
        public string ControllerName { get; set; }

        public double StartBalance { get; set; }
        public double BilledAmount { get; set; }
        public double PlanAmount { get; set; }

        public double RaisedAmount { get; set; }

        public double Percent
        {
            get { return PlanAmount == 0 ? 0 : 100*RaisedAmount/PlanAmount; }
        }
    }
}
