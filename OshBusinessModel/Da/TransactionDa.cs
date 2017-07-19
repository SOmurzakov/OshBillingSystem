using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OshBusinessModel.Da
{
    public class TransactionDa
    {
        public int TransactionId { get; set; }
        public int ContractId { get; set; }
        public string ContractNumber { get; set; }
        public DateTime DateAsOf { get; set; }
        public string ReceiptNo { get; set; }
        public double Amount { get; set; }
        public DateTime Date { get; set; }
        public int SubagentId { get; set; }
        public string SubagentName { get; set; }
        public int UserId { get; set; }
        public string UserName { get; set; }
        public int RegisteredUserId { get; set; }
        public string RegisteredUserName { get; set; }

        public int ContractArchiveId { get; set; }
        public string FullAddress { get; set; }
        public string FullName { get; set; }
    }
}
