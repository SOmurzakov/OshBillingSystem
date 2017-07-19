using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OshBusinessModel.Da.Mobiles
{
    public class MobileContractModel
    {

        // Subscriber
        public int SubscriberId { get; set; }
        public DateTime RegisteredAtSystem { get; set; }
        public string SubscriberType { get; set; }
        public string SubscriberName { get; set; }
        public string PassportNumber { get; set; }
        public string PassportWhere { get; set; }
        public DateTime PassportDate { get; set; }
        public string SubscriberPhone { get; set; }
        public string SubscriberRemarks { get; set; }
        public bool InvoiceRequired { get; set; }
        public string Inn { get; set; }
        public string Ugkns { get; set; }
        public string Mfo { get; set; }
        public string SubscriberFullAddress { get; set; }
        public string TypeAsString { get; set; }

        // contract
        public int ContractId { get; set; }
        public double RegistrationDebt { get; set; }
        public string ContractName { get; set; }
        public int AreaId { get; set; }
        public string AreaName { get; set; }
        public string ContractPhone { get; set; }
        public string TariffId { get; set; }
        public int PeopleRegistered { get; set; }
        public double FixedConsumption { get; set; }
        public string ContractFullAddress { get; set; }
        public bool IsOpen { get; set; }
        public DateTime RegistrationDate { get; set; }
        public string ContractNumber { get; set; }
        public string TariffName { get; set; }

        public double ContractDebt { get; set; }
        public ShowContract.ContractOptionsDa[] Options { get; set; }
        public ShowContract.ContractMeterDa[] Meters { get; set; }

    }

}
