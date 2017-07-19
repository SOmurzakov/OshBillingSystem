using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OshBusinessModel.Da.Accountant
{
    public class RbcTransactionDa
    {
        public int ControllerId { get; set; }
        public int SubagentId { get; set; }
        public int UserId { get; set; }
        public double Amount { get; set; }
        public int Count { get; set; }
    }
}
