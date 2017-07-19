using OshBusinessModel.J2MeDb.Dto;

namespace OshBusinessModel.J2MeDb.Requests
{
    public class SetMetersValuesRequest
    {
        public string session { get; set; }
        public int rootingId { get; set; }
        public MeterDto[] meters { get; set; }
    }
}
