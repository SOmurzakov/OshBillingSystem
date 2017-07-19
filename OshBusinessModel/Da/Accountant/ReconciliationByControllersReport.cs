using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OshBusinessModel.Da.Accountant
{
    public class ReconciliationByControllersReport
    {
        public DateTime DateStart { get; set; }
        public DateTime DateEnd { get; set; }

        public RbcUserDa[] Users { get; set; }
        public RbcSubagentDa[] Subagents { get; set; }
        public RbcTransactionDa[] Transactions { get; set; }
    }
}
