using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OshBusinessModel.Da.Rootings
{
    public class RootingContractForControllerDa
    {

        public string Type { get; set; }

        public int ContractId { get; set; }
        public string ContractNumber { get; set; }
        public string FullAddress { get; set; }
        public string Name { get; set; }
        public string TariffName { get; set; }
        public int PeopleRegistered { get; set; }
        public bool HasSewage { get; set; }
        public double Allowance { get; set; }
        public int AreaId { get; set; }

        public double StartBalance { get; set; }
        public double StartDebit { get; set; }
        public double StartCredit { get; set; }
        public double BilledAmount { get; set; }
        public double PayedAmount { get; set; }
        public double EndDebit { get; set; }
        public double EndCredit { get; set; }
        public double EndBalance { get; set; }
        public double CubicMeters { get; set; }
        public double CubicMetersSewage { get; set; }

    }
}
