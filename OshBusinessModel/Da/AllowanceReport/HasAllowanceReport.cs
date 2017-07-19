namespace OshBusinessModel.Da.AllowanceReport
{
    public class HasAllowanceReport
    {
        public AllowanceReportControllerDa[] Controllers { get; set; }
        public AllowanceReportTariffDa[] Tariffs { get; set; }
        public AllowanceReportItemDa[] Items { get; set; }
    }
}