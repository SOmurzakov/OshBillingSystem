using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OshBusinessModel.Da.SubagentsBillingPeriods
{
    public class SubagentDa
    {
        public int SubagentId { get; set; }
        public string SubagentName { get; set; }
        public bool IsSystem { get; set; }
        public double Amount { get; set; }
    }
}
