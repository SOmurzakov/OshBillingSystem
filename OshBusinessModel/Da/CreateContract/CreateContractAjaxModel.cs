namespace OshBusinessModel.Da.CreateContract
{
    public class CreateContractAjaxModel
    {
        public int SubscriberId { get; set; }
        public CPCAM_Subscriber Subscriber { get; set; }
        public CPCAM_Contract Contract { get; set; }
        public CreateContractMeterInfo[] Meters { get; set; }
        public CPCAM_TariffOption[] Options { get; set; }
        public string RegistrationDebt { get; set; }
        public string RegistrationDate { get; set; }
    }
}