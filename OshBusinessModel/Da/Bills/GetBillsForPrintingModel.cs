using OshBusinessModel.Da.Areas;
using OshBusinessModel.Da.Controller;
using OshBusinessModel.Da.SubagentsBillingPeriods;

namespace OshBusinessModel.Da.Bills
{
    public class GetBillsForPrintingModel
    {
        public int PeriodId { get; set; }
        public int ControllerId { get; set; }
        public int AreaId { get; set; }

        public BillingPeriodDa[] BillingPeriods { get; set; }
        public ControllerShortInfoDa[] Controllers { get; set; }
        public AreasShortInfoDa[] Areas { get; set; }

        public Bill[] Bills { get; set; }

        public string[] Streets { get; set; }
    }
}