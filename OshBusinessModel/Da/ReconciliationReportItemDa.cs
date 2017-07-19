using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OshBusinessModel.Da
{
    public class ReconciliationReportItemDa
    {
        public int SubagentId { get; set; }
        public string Subagent { get; set; }
        public double Amount { get; set; }
        public bool IsSubagent { get; set; }
        public bool IsSystem { get; set; }
        public int TransactionCount { get; set; }
        public string UserType { get; set; }
    }
}
