namespace OshBusinessModel.Da.Debtors
{
    public class DebtorDa
    {
        public int ContractId { get; set; }
        public string ContractNumber { get; set; }
        public string Tariff { get; set; }
        public string Name { get; set; }
        public int SubscriberId { get; set; }
        public string FullAddress { get; set; }
        public string Type { get; set; }
        public string BudgetType { get; set; }

        public double StartBalance { get; set; }
        public double BilledAmount { get; set; }
        public double PayedCash { get; set; }
        public double PayedBank { get; set; }
        public double SubagentRecalc { get; set; }
        public double SubagentCross { get; set; }
        public double SubagentAdd { get; set; }
        public double EndBalance { get; set; }
    }
}
