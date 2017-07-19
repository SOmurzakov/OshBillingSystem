namespace OshBusinessModel.Da.AllowanceReport
{
    public class WithoutAllowanceReport
    {
        public AllowanceReportControllerDa[] Controllers { get; set; }
        public AllowanceReportTariffDa[] Tariffs { get; set; }
        public AllowanceReportTariffOptionDa[] TariffOptions { get; set; }
        public AllowanceReportItemDa[] Items { get; set; }
        public AllowanceReportItemOptionDa[] ItemOptions { get; set; }
    }
}