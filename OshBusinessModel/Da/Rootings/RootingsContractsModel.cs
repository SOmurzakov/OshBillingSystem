using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OshBusinessModel.Da.Rootings
{
    public class RootingsContractsModel
    {
        public int AreaId { get; set; }
        public string AreaName { get; set; }
        public int ControllerId { get; set; }
        public string ControllerName { get; set; }
        public string AddressStreet { get; set; }
        public string AddressBuilding { get; set; }
        public RootingsContractsDa[] Contracts { get; set; }
        public RootingsAreasDa[] Areas { get; set; }
        public RootingsTotalDa Total
        {
            get
            {
                return new RootingsTotalDa()
                {
                    PeopleRegistered = Contracts.Sum(r => r.PeopleRegistered),
                    Debt = Contracts.Sum(r => r.Debt)
                };
            }
        }
    }
    public class RootingsTotalDa
    {
        public int PeopleRegistered { get; set; }
        public double Debt { get; set; }
    }
}
