using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OshBusinessModel.Da.ShowContract
{
    public class ContractChangeMeterActionDa : ContractChangeItemDa
    {

        public int MeterId { get; set; }
        public string Action { get; set; }
        public string SerialNumber { get; set; }

        public override int Weight
        {
            get { return 10; }
        }

        public override string Subcategory
        {
            get { return "MetersActions"; }
        }

    }
}
