using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OshBusinessModel.Da.Rootings
{
    public class RootingsContractsDa
    {
        public int ContractId { get; set; }
        public string ContractNumber { get; set; }
        public int SubscriberId { get; set; }
        public string SubscriberName { get; set; }
        public string FullAddress { get; set; }
        //public int MetersCount { get; set; }
        //public bool ValuesProvided { get; set; }
        public string TariffId { get; set; }
        public string TariffName { get; set; }
        public double Debt { get; set; }
        public DateTime LastBillPeriodEnd { get; set; }
        public int PeopleRegistered { get; set; }
    }
}
