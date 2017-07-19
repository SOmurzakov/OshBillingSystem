using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OshBusinessModel.Da.Billing
{
    public class BillingRequestDa
    {
        public int Id { get; set; }
        public string Qid { get; set; }
        public DateTime Date { get; set; }
        public string Request { get; set; }
        public string Response { get; set; }
        public int ProcessStatus { get; set; }

        public int SubagentId { get; set; }
        public string Operation { get; set; }
        public int ContractId { get; set; }
        public double Amount { get; set; }
    }
}
