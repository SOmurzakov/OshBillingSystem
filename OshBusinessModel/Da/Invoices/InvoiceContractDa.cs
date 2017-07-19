using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OshBusinessModel.Da.Invoices
{
    public class InvoiceContractDa
    {
        public int ContractId { get; set; }
        public int SubscriberId { get; set; }
        public string ContractName { get; set; }
        public string ContractNumber { get; set; }

        public double CubicMeters { get; set; }
        public double CubicMetersSewage { get; set; }
        public double AmountWater { get; set; }
        public double AmountSewage { get; set; }
        public double AmountNds { get; set; }
        public double AmountNsp { get; set; }

        public double FixedConsumption { get; set; }
        public double FixedConsumptionSewage { get; set; }
        public bool HasSewage { get; set; }
        public double SewagePricePerCubicMeter { get; set; }
        public double WaterPricePerCubicMeter { get; set; }

        public double LastMetersValue { get; set; }
        public double CurrentMeterValue { get; set; }

        public double Debt { get; set; }

        public double NdsValue
        {
            get { return AmountSewage + AmountWater != 0 ? AmountNds * 100 / (AmountSewage + AmountWater) : 0; }
        }

        public double NspValue
        {
            get { return AmountSewage + AmountWater != 0 ? AmountNsp * 100 / (AmountSewage + AmountWater) : 0; }
        }

        public double AmountNdsForWater
        {
            get { return NdsValue * AmountWater / 100; }
        }

        public double AmountNdsForSewage
        {
            get { return NdsValue * AmountSewage / 100; }
        }

        public double Total
        {
            get { return AmountWater + AmountSewage + AmountNds + AmountNsp; }
        }

        public double WaterTotal
        {
            get { return AmountWater + AmountNdsForWater; }
        }

        public double SewageTotal
        {
            get { return AmountSewage + AmountNdsForSewage; }
        }

        //

        public double PricePerCubicMeter
        {
            get { return WaterPricePerCubicMeter + (HasSewage ? SewagePricePerCubicMeter : 0); }
        }

        public double TotalWithoutNdsAndNsp
        {
            get { return AmountWater + AmountSewage; }
        }

        public double TotalWithNds
        {
            get { return TotalWithoutNdsAndNsp + AmountNds; }
        }

        public double TotalNds
        {
            get { return AmountNdsForWater + AmountNdsForSewage; }
        }
    }
}
