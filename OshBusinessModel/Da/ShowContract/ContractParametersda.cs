using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OshBusinessModel.Da.ShowContract
{
    public class ContractParametersDa : ContractChangeItemDa
    {
        public int PeopleRegistered { get; set; }
        public double FixedConsumption { get; set; }
        public double FixedConsumptionSewage { get; set; }
        public bool HasSewage { get; set; }
        public double Allowance { get; set; }
        public string AllowanceReason { get; set; }

        public override int Weight
        {
            get { return 2; }
        }

        public override string Subcategory
        {
            get { return "ContractsParameters"; }
        }
    }
}
