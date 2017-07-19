using OshBusinessModel.J2MeDb.Dto;

namespace OshBusinessModel.J2MeDb.Responses
{
    public class GetRootingDetailsResponse
    {
        public int rootingId { get; set; }
        public int contractId { get; set; }
        public string contractNumber { get; set; }
        public string owner { get; set; }
        public string address { get; set; }
        public string debt { get; set; }
        public string lastPaymentDate { get; set; }
        public string lastValuesProvided { get; set; }
        public MeterDto[] meters { get; set; }
    }
}
