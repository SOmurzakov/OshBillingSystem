using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OshBusinessModel.Da.Subagents
{
    public class SubagentTransactionDa
    {
        public int TransactionId { get; set; }
        public int ContractId { get; set; }
        public string ContractNumber { get; set; }
        public int SubscriberId { get; set; }
        public string SubscriberName { get; set; }
        public string FullAddress { get; set; }
        public DateTime DateAsOf { get; set; }
        public double Amount { get; set; }
        public int UserId { get; set; }
        public string UserName { get; set; }
    }
}
