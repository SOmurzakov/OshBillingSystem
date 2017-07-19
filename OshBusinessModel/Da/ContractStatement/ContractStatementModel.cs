using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using OshBusinessModel.Da.SubagentsBillingPeriods;

namespace OshBusinessModel.Da.ContractStatement
{
    public class ContractStatementModel
    {
        public bool Found { get; set; }
        public int ContractId { get; set; }
        public string Name { get; set; }
        public int StartPeriodId { get; set; }
        public int EndPeriodId { get; set; }

        public BillingPeriodDa[] BillingPeriods { get; set; }
        public ContractStatementDa[] Statements { get; set; }
    }
}
