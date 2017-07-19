using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OshBusinessModel.Da
{
    public class ContractBillDa
    {
        public int ContractId { get; set; }
        public string ContractNumber { get; set; }
        public int BillId { get; set; }
        public DateTime PeriodStart { get; set; }
        public DateTime PeriodEnd { get; set; }
        public int Days { get; set; }
        public double CubicMetersCount { get; set; }
        public double AmountWater { get; set; }
        public double AmountSewage { get; set; }
        public double AmountCar { get; set; }
        public double AmountCattle { get; set; }
        public double AmountIrrigation { get; set; }
        public double AmountBathWater { get; set; }
        public double AmountBathSewage { get; set; }
        public double AmountAllBeforeTax { get; set; }
        public double AmountTax1 { get; set; }
        public double AmountTax2 { get; set; }
        public double AmountAllAfterTax { get; set; }
        public double Debt { get; set; }
        public DateTime Date { get; set; }
        public double AmountToPay { get; set; }
        public string BillIdentifier { get; set; }

        public string Address { get; set; }
        public int PeopleRegistered { get; set; }
        public int CarsCount { get; set; }
        public int CattleCount { get; set; }
        public int IrrigationMeters { get; set; }
        public bool HasBath { get; set; }

        public string Tariff { get; set; }
        public double LitersPerPersonPerDay { get; set; }
        public double WaterPricePerCubicMeter { get; set; }
        public double SewagePricePerCubicMeter { get; set; }
        public double TaxPercent1 { get; set; }
        public double TaxPercent2 { get; set; }
        public double PricePerIrrigationSquareMeter { get; set; }
        public double PricePerCattlePerYear { get; set; }
        public double PricePerCarPerYear { get; set; }
        public double BathWaterPricePerPersonPerYear { get; set; }
        public double BathSewagePricePerPersonPerYear { get; set; }

        public string Name { get; set; }
        public string Area { get; set; }


        public ContractBillMeterDa[] Meters { get; set; }
    }
}
