namespace OshBusinessModel.Da.BulkPayments
{
    public class BulkPaymentContractInfoDa
    {
        public bool Found { get; set; }
        public int ContractId { get; set; }
        public int ArchiveId { get; set; }
        public string ContractNumber { get; set; }
        public string Area { get; set; }
        public string Subscriber { get; set; }
        public string Address { get; set; }
        public double Debt { get; set; }

        public BkciOptionsDa[] Options { get; set; }

        public string DebtAsString
        {
            get { return Debt.ToString("0.00"); }
        }
    }
}