namespace OshBusinessModel.J2MeDb.Requests
{
    public class RegisterPaymentRequest
    {
        public string session { get; set; }
        public int rootingId { get; set; }
        public int amount { get; set; }
    }
}
