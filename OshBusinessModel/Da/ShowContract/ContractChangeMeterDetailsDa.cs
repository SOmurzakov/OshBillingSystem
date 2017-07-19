using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OshBusinessModel.Da.ShowContract
{
    public class ContractChangeMeterDetailsDa : ContractChangeItemDa
    {

        public int MeterId { get; set; }
        public string SerialNumber { get; set; }

        public override int Weight
        {
            get { return 11; }
        }

        public override string Subcategory
        {
            get { return "MetersDetails"; }
        }
        
    }
}
