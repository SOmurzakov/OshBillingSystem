using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OshBusinessModel.Da.Bills
{
    public class Bill
    {
        public BillContractDetailsDa ContractDetails { get; set; }
        public BillDa BillDetails { get; set; }
        public BillMeterDa[] Meters { get; set; }
        public BillTariffOptionDa[] Options { get; set; }
    }
}
