using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OshBusinessModel.Da.Tariffs
{
    public class TariffDictionaryDa
    {
        public string SemanticId { get; set; }
        public string SubscriberType { get; set; }
        public string Subtype { get; set; }
        public bool Enabled { get; set; }
        public string Name { get; set; }
        public DateTime Date { get; set; }
        public double LitersPerPersonPerDay { get; set; }
        public double WaterPricePerCubicMeter { get; set; }
        public double SewagePricePerCubicMeter { get; set; }
        public int ContractsCount { get; set; }
        public string ShortName { get; set; }

        public TariffOptionDictionaryDa[] TariffOptions { get; set; }
    }
}
