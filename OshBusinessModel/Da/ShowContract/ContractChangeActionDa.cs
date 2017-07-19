using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OshBusinessModel.Da.ShowContract
{
    public class ContractChangeActionDa : ContractChangeItemDa
    {
        public string Action { get; set; }

        public override int Weight
        {
            get { return 0; }
        }

        public override string Subcategory
        {
            get { return "ContractAction"; }
        }

        public string ActionToString {get { return Action == "created" ? "создан" : Action == "opened" ? "возобновлен" : "приостановлен"; }}
    }
}
