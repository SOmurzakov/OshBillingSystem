using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OshBusinessModel.Da.BulkPayments
{
    public class BulkPaymentDa
    {
        public int ContractId { get; set; }
        public string ReceiptNo { get; set; }
        public double Amount { get; set; }
    }
}
