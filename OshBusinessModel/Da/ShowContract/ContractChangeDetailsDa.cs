using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OshBusinessModel.Da.ShowContract
{
    public class ContractChangeDetailsDa : ContractChangeItemDa
    {
        public string ContractName { get; set; }
        public string AddressStreet { get; set; }
        public string AddressBuilding { get; set; }
        public string AddressFlat { get; set; }
        public int AreaId { get; set; }
        public string Phone { get; set; }
        public string AreaName { get; set; }
        public int ArchiveId { get; set; }
        public string BudgetType { get; set; }

        public string FullAddress
        {
            get { return (AddressStreet + " " + AddressBuilding + " " + AddressFlat).Trim(); }
        }

        public override int Weight
        {
            get { return 1; }
        }

        public override string Subcategory
        {
            get { return "ContractsDetails"; }
        }
    }
}
