using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OshBusinessModel.Da.ReportByControllers
{
    public class ReportByDistrictsDa
    {
        public string AreaName { get; set; }
        public string ControllerName { get; set; }
        public string AddressStreet { get; set; }
        public string AddressBuilding { get; set; }
        public int ContractsCount { get; set; }
        public int PeopleRegistered { get; set; }
        public double StartDebit { get; set; }
        public double StartCredit { get; set; }
        public double AmountBilled { get; set; }
        public double AmountNsp { get; set; }
        public double TransactionsAmount { get; set; }
        public double SystemTransactionsAmount { get; set; }
        public double EndDebit { get; set; }
        public double EndCredit { get; set; }
    }
    public class ReportByControllersDa
    {
        public int AreaId { get; set; }
        public string AreaName { get; set; }
        public int ControllerId { get; set; }
        public string ControllerName { get; set; }
        public string TariffId { get; set; }
        public string TariffOptionId { get; set; }
        public string TariffName { get; set; }
        public string StreetName { get; set; }
        public int ContractsCount { get; set; }
        public int PeopleRegistered { get; set; }
        public double StartDebit { get; set; }
        public double StartCredit { get; set; }
        public double BilledWaterAmount { get; set; }
        public double BilledWaterCubicMeters { get; set; }
        public double BilledWaterNds { get; set; }
        public double BilledWaterNsp { get; set; }
        public double BilledSewageAmount { get; set; }
        public double BilledSewageCubicMeters { get; set; }
        public double BilledSewageNds { get; set; }
        public double BilledSewageNsp { get; set; }
        public double BilledAmount { get; set; }
        public double TransactionsAmount { get; set; }
        public double SystemTransactionsAmount { get; set; }
        public double EndDebit { get; set; }
        public double EndCredit { get; set; }
    }
}
