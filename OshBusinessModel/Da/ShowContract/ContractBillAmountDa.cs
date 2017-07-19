using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OshBusinessModel.Da.ShowContract
{
    public class ContractBillAmountDa : IDateable
    {
        public string PeriodName { get; set; }
        public DateTime Date { get; set; }
        public int BillId { get; set; }
        public double Amount { get; set; }

    }
}
