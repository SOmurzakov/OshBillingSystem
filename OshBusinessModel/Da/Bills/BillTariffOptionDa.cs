using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OshBusinessModel.Da.Bills
{
    public class BillTariffOptionDa
    {
        public int BillTariffOptionId { get; set; }
        public int BillId { get; set; }
        public int TariffOptionId { get; set; }
        public double Value { get; set; }
        public double LitersPerDay { get; set; }
        public double BilledAmount { get; set; }
        public string VariableBillName { get; set; }
        public string VariableDescription { get; set; }
    }
}
