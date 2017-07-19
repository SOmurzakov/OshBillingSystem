using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OshChannel.Models
{
    public class ChangeTariffPriceAjaxModel
    {
        public string TariffId { get; set; }
        public string TariffName { get; set; }
        public string LitersPerPersonPerDay { get; set; }
        public string WaterPricePerCubicMeter { get; set; }
        public string SewagePricePerCubicMeter { get; set; }
    }

    public class ChangeTariffOptionAjaxModel
    {
        public string TariffOptionId { get; set; }
        public string LitersPerDay { get; set; }
    }
}