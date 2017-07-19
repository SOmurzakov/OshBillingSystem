using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OshBusinessModel.Da.Tariffs
{
    public class TariffChangesDa
    {
        public DateTime Date { get; set; }
        public int UserId { get; set; }
        public string UserName { get; set; }
        public double LitersPerPersonPerDay { get; set; }
        public double WaterPricePerCubicMeter { get; set; }
        public double SewagePricePerCubicMeter { get; set; }
    }
}
