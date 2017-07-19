using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OshBusinessModel.Da.ShowContract
{
    public class ContractDetailsDa
    {
        public int ContractId { get; set; }
        public int SubscriberId { get; set; }
        public double RegistrationDebt { get; set; }
        public string ContractName { get; set; }
        public int AreaId { get; set; }
        public string AreaName { get; set; }
        public int ControllerId { get; set; }
        public string ControllerName { get; set; }
        public string Phone { get; set; }
        public string TariffId { get; set; }
        public int PeopleRegistered { get; set; }
        public double FixedConsumption { get; set; }
        public double FixedConsumptionSewage { get; set; }
        public string FullAddress { get; set; }
        public bool IsOpen { get; set; }
        public DateTime RegistrationDate { get; set; }
        public string ContractNumber { get; set; }
        public string TariffName { get; set; }

        public string AddressStreet { get; set; }
        public string AddressBuilding { get; set; }
        public string AddressFlat { get; set; }

        public double ContractDebt { get; set; }

        public int ArchiveId { get; set; }
        public string BudgetType { get; set; }
        public bool HasSewage { get; set; }
        public double Allowance { get; set; }
        public string AllowanceReason { get; set; }
    }
}
