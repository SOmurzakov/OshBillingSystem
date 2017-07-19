using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OshBusinessModel.Da.Bills
{
    public class BillDa
    {
        public string ContractName { get; set; }

        public int BillId { get; set; }
        public int BillingPeriodId { get; set; }
        public string BillingPeriodName { get; set; }
        public int ContractId { get; set; }
        public DateTime PeriodStart { get; set; }
        public DateTime PeriodEnd { get; set; }
        public int PeriodDays { get; set; }
        public double FixedConsumption { get; set; }
        public double FixedConsumptionSewage { get; set; }
        public int PeopleRegistered { get; set; }
        public double CubicMeters { get; set; }
        public double CubicMetersSewage { get; set; }
        public double Debt { get; set; }
        public int TariffPriceId { get; set; }
        public double LitersPerPersonPerDay { get; set; }
        public double WaterPricePerCubicMeter { get; set; }
        public double SewagePricePerCubicMeter { get; set; }
        public double AmountWater { get; set; }
        public double AmountSewage { get; set; }
        public double AmountTotal { get; set; }
        public double AmountPenalty { get; set; }
        public double AmountNds { get; set; }
        public double AmountNsp { get; set; }
        public double AmountAllAfterTaxes { get; set; }
        public int UserId { get; set; }
        public DateTime Date { get; set; }
        public string TariffName { get; set; }

        public bool HasSewage { get; set; }
        public double Allowance { get; set; }
        public double AmountTotalAfterAllowance { get; set; }

        public double Billed { get { return AmountTotalAfterAllowance + AmountNds + AmountNsp + AmountPenalty; } }
        public double AmountToPay { get { return AmountAllAfterTaxes-AmountPaid; } }

        public double AmountForMonth { get { return AmountTotal + AmountNds + AmountNsp; } }
        public double AmountPaid { get; set; }
    }
}
