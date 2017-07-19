using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OshBusinessModel.Da.ShowContract
{
    public class ContractOptionsDa
    {
        public int ContractTariffOptionId { get; set; }
        public bool Enabled { get; set; }
        public double Value { get; set; }
        public string TariffOptionId { get; set; }
        public string TariffOptionName { get; set; }
        public string VariableBillName { get; set; }
        public string VariableDescription { get; set; }
        public bool UsePeopleRegistered { get; set; }

        public bool HasSewage { get; set; }
        public bool SewageAvailable { get; set; }
    }
}
