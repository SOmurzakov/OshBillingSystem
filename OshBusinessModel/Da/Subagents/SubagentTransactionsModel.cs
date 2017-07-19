using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OshBusinessModel.Da.Subagents
{
    public class SubagentTransactionsModel
    {
        public string Name { get; set; }
        public SubagentTransactionDa[] Transactions { get; set; }
    }
}
