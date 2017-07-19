using OshBusinessModel.Da.Bills;

namespace OshChannel.Models
{
    public class GetContractInfoAjaxModel
    {
        public string KeyValue { get; set; }
        public string SearchCriteria { get; set; }
    }

    public class BulkPaymentsAjaxModel
    {
        public int UseController { get; set; }
        public int SubagentId { get; set; }
        public int UserId { get; set; }
        public string Date { get; set; }

        public BulkPaymentItem[] Payments { get; set; }
    }

    public class BulkPaymentItem
    {
        public int ContractId { get; set; }
        public string ReceiptNo { get; set; }
        public string Amount { get; set; }
    }

    public class GetBillsForAddressModel
    {
        public int PeriodId { get; set; }
        public string Street { get; set; }
        public bool AllBuildings { get; set; }
        public ShortBuildingDa[] Buildings { get; set; }
        public int ControllerId { get; set; }
    }
}