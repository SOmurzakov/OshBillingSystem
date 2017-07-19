using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OshBusinessModel.Da.CreateContract
{
    public class CreateContractContractInfo
    {
        public string AddressStreet { get; set; }
        public string AddressBuilding { get; set; }
        public string AddressFlat { get; set; }
        public string Phone { get; set; }
        public int TariffId { get; set; }
        public int AreaId { get; set; }
        public int PeopleRegistered { get; set; }
        public int CarsCount { get; set; }
        public int CattleCount { get; set; }
        public int IrrigationMeters { get; set; }
        public bool HasBath { get; set; }
        public double RegistrationDebt { get; set; }

        public CreateContractMeterInfo[] Meters { get; set; }
    }
}
