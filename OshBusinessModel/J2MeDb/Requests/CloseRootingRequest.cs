namespace OshBusinessModel.J2MeDb.Requests
{
    public class CloseRootingRequest
    {
        public string session { get; set; }
        public int rootingId { get; set; }
        public int reasonId { get; set; }
    }
}
