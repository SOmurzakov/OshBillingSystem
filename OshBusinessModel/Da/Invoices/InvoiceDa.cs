using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OshBusinessModel.Da.Invoices
{
    public class InvoiceDa
    {
        public int StartBillingPeriodId { get; set; }
        public string StartBillingPeriodName { get; set; }
        public int EndBillingPeriodId { get; set; }
        public string EndBillingPeriodName { get; set; }
        public int SubscriberId { get; set; }
        public DateTime Date { get; set; }
        public int InvoiceNo { get; set; }
        public string Series { get; set; }

        public string SupplierInn { get; set; }
        public string SupplierName { get; set; }
        public string SupplierFullAddress { get; set; }
        public string SupplierUgknsCode { get; set; }
        public string SupplierUgknsName { get; set; }
        public string SupplierBankCode { get; set; }
        public string SupplierBankName { get; set; }
        public string SupplierBankAccount { get; set; }

        public string SubscriberInn { get; set; }
        public string SubscriberName { get; set; }
        public string SubscriberFullAddress { get; set; }
        public string SubscriberUgknsCode { get; set; }
        public string SubscriberUgknsName { get; set; }
        public string SubscriberBankCode { get; set; }
        public string SubscriberBankName { get; set; }
        public string SubscriberBankAccount { get; set; }
        public int InvoiceId { get; set; }

        public InvoiceContractDa[] Contracts { get; set; }

        public string PeriodName
        {
            get
            {
                return StartBillingPeriodId == EndBillingPeriodId
                           ? StartBillingPeriodName
                           : StartBillingPeriodName + " - " + EndBillingPeriodName;
            }
        }

        public double NspValue
        {
            get { var contract = Contracts.FirstOrDefault(c => c.NspValue > 0);
                return contract != null ? contract.NspValue : 0;
            }
        }

        public double TotalNsp
        {
            get { return Contracts.Sum(c => c.AmountNsp); }
        }

        public double TotalCubicMeters
        {
            get { return Contracts.Sum(c => c.CubicMeters); }
        }

        public double TotalWithoutNdsAndNsp
        {
            get { return Contracts.Sum(c => c.TotalWithoutNdsAndNsp); }
        }

        public double TotalWithNds
        {
            get { return Contracts.Sum(c => c.TotalWithNds); }
        }

        public double TotalNds
        {
            get { return Contracts.Sum(c => c.TotalNds); }
        }

        public double TotalDebt
        {
            get { return Contracts.Sum(c => c.Debt); }
        }

        public double Total
        {
            get { return Contracts.Sum(c => c.Total); }
        }

        public double AmountPaid { get; set; }
    }
}
