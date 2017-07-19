using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OshBusinessModel.Da.Billing
{
    public class BillingTerminalsDa
    {
        public int SubagentId { get; set; }
        public string IpAddress { get; set; }
        public string Sid { get; set; }
        public bool HasBalance { get; set; }
        public double CurrentBalance { get; set; }
    }
}
