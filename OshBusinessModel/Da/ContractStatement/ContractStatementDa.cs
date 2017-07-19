using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OshBusinessModel.Da.ContractStatement
{
    public class ContractStatementDa
    {
        public int PeriodId { get; set; }
        public string PeriodName { get; set; }
        public double StartBalance { get; set; }
        public double BilledAmount { get; set; }
        public double SubagentsAmount { get; set; }
        public double PayedAmount { get; set; }
        public double EndBalance { get; set; }
    }
}
