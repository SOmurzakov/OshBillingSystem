using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OshBusinessModel.Da.ShowContract
{
    public class ContractChangeTariffOptionActionDa : ContractChangeItemDa
    {
        public string Action { get; set; }
        public string SemanticId { get; set; }
        public string VariableBillName { get; set; }
        public string VariableDescription { get; set; }

        public override string Subcategory
        {
            get { return "TariffOptionsActions"; }
        }

        public override int Weight
        {
            get { return 20; }
        }

        public string ActionToString
        {
            get { return Action == "enabled" ? "Активирована" : "Отменена"; }
        }
    }
}
