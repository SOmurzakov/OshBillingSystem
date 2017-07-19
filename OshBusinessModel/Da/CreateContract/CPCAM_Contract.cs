using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OshBusinessModel.Da.CreateContract
{
    public class CPCAM_Contract
    {
        public int ArchiveId { get; set; }
        public string Name { get; set; }
        public int AreaId { get; set; }
        public string AddressStreet { get; set; }
        public string AddressBuilding { get; set; }
        public string AddressFlat { get; set; }
        public string Phone { get; set; }
        public string Tariff { get; set; }
        public int PeopleRegistered { get; set; }
        public string FixedConsumption { get; set; }
        public string BudgetType { get; set; }
        public string HasSewage { get; set; }
        public string Allowance { get; set; }
        public string AllowanceReason { get; set; }
        public string FixedConsumptionSewage { get; set; }
    }
}
