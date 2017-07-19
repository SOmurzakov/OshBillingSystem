using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OshBusinessModel.Da.ShowContract
{
    public class ContractChangeTariffOptionValueDa : ContractChangeItemDa
    {

        public string SemanticId { get; set; }
        public string VariableBillName { get; set; }
        public string VariableDescription { get; set; }
        public double Value { get; set; }
        public bool UsePeopleRegistered { get; set; }
        public bool HasSewage { get; set; }

        public override int Weight
        {
            get { return 21; }
        }

        public override string Subcategory
        {
            get { return "TariffOptionValue"; }
        }

        public string VariableToString
        {
            get { return string.Format("{0} ({1})", VariableBillName, VariableDescription); }
        }
    }
}
