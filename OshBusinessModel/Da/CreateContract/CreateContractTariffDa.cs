namespace OshBusinessModel.Da.CreateContract
{
    public class CreateContractTariffDa
    {
        public string SemanticId { get; set; }
        public string Name { get; set; }
        public string SubscriberType { get; set; }
        public string Subtype { get; set; }
        public double LitersPerPersonPerDay { get; set; }

        public double WaterPricePerCubicMeter { get; set; }
        public double SewagePricePerCubicMeter { get; set; }

        public bool IsSewageOnly { get { return WaterPricePerCubicMeter == 0 && SewagePricePerCubicMeter > 0; } }
    }
}
