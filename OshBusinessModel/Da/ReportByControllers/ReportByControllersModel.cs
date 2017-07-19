using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using OshBusinessModel.Da.SubagentsBillingPeriods;

namespace OshBusinessModel.Da.ReportByControllers
{
    public class ReportByDistrictsModel
    {
        public string DistrictName { get; set; }
        public int BillingPeriodId { get; set; }
        public BillingPeriodDa[] BillingPeriods { get; set; }
        public DistrictNameDa[] DistrictNames { get; set; }

        public ReportByDistrictsDa[] Report { get; set; }
        public ReportByDistrictsDa Total { get 
        {
            return new ReportByDistrictsDa()
            {
                ContractsCount = Report.Sum(r => r.ContractsCount),
                PeopleRegistered = Report.Sum(r => r.PeopleRegistered),
                StartDebit = Report.Sum(r => r.StartDebit),
                StartCredit = Report.Sum(r => r.StartCredit),
                AmountBilled = Report.Sum(r => r.AmountBilled),
                AmountNsp = Report.Sum(r => r.AmountNsp),
                TransactionsAmount = Report.Sum(r => r.TransactionsAmount),
                SystemTransactionsAmount = Report.Sum(r => r.SystemTransactionsAmount),
                EndDebit = Report.Sum(r => r.EndDebit),
                EndCredit = Report.Sum(r => r.EndCredit)
            };
        } 
        }
    }
    public class ReportByControllersModel
    {
        public int StartPeriodId { get; set; }
        public int EndPeriodId { get; set; }
        public BillingPeriodDa[] BillingPeriods { get; set; }

        public int ControllerId { get; set; }
        public ControllerShortModel[] Controllers { get; set; }

        public ReportByControllersDa[] Report { get; set; }
        public ReportByControllersDa[] TariffOptions { get; set; }

        public ReportByControllersDa Total { get
        {
            ReportByControllersDa total =
                new ReportByControllersDa()
                    {
                        ContractsCount = Report.Sum(r => r.ContractsCount),
                        PeopleRegistered = Report.Sum(r => r.PeopleRegistered),
                        StartDebit = Report.Sum(r => r.StartDebit),
                        StartCredit = Report.Sum(r => r.StartCredit),

                        BilledWaterAmount = Report.Sum(r => r.BilledWaterAmount),
                        BilledWaterCubicMeters = Report.Sum(r => r.BilledWaterCubicMeters),
                        BilledWaterNds = Report.Sum(r => r.BilledWaterNds),
                        BilledWaterNsp = Report.Sum(r => r.BilledWaterNsp),

                        BilledSewageAmount = Report.Sum(r => r.BilledSewageAmount),
                        BilledSewageCubicMeters = Report.Sum(r => r.BilledSewageCubicMeters),
                        BilledSewageNds = Report.Sum(r => r.BilledSewageNds),
                        BilledSewageNsp = Report.Sum(r => r.BilledSewageNsp),
                        BilledAmount = Report.Sum(r => r.BilledAmount),

                        TransactionsAmount = Report.Sum(r => r.TransactionsAmount),
                        SystemTransactionsAmount = Report.Sum(r => r.SystemTransactionsAmount),
                        EndCredit = Report.Sum(r => r.EndCredit),
                        EndDebit = Report.Sum(r => r.EndDebit),
                    };

            return total;
        }}


    }

    public class ControllerShortModel
    {
        public int ControllerId { get; set; }
        public string ControllerName { get; set; }
    }

    public class DistrictNameDa
    {
        public string DistrictName { get; set; }
    }
}
