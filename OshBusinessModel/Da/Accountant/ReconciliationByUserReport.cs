using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OshBusinessModel.Da.Accountant
{
    public class ReconciliationByUserReport
    {
        public DateTime DateStart { get; set; }
        public DateTime DateEnd { get; set; }
        public int UserId { get; set; }
        public int SubagentId { get; set; }
        public TransactionDa[] Transactions { get; set; }

        public double Amount
        {
            get { return Transactions.Sum(t => t.Amount); }
        }
    }
}
