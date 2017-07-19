using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OshBusinessModel.Da.ShowContract
{
    public class ContractTransactionDa : IDateable
    {
        public int TransactionId { get; set; }
        public DateTime DateAsOf { get; set; }
        public string ReceiptNo { get; set; }
        public double Amount { get; set; }

        public int SubagentId { get; set; }
        public string SubagentName { get; set; }

        public int UserId { get; set; }
        public string UserName { get; set; }

        public bool VisaRequired { get; set; }
        public int VisaGivenUserId { get; set; }
        public string VisaGivenUserName { get; set; }
        public DateTime? VisaGivenDate { get; set; }
        public bool IsSystem { get; set; }
        public string Remarks { get; set; }

        public int RegisteredUserId { get; set; }
        public string RegisteredUserName { get; set; }

        public DateTime Date { get { return DateAsOf; } }

    }
}
