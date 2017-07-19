namespace OshChannel.Models
{
    public class EditSeriesAjaxModel
    {
        public int Id { get; set; }
        public string SeriesNo { get; set; }
        public int StartId { get; set; }
        public int Length { get; set; }
    }

    public class ChangeInvoiceNumberModel
    {
        public int Id { get; set; }
        public int Number { get; set; }
    }
}