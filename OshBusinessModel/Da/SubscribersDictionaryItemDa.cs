using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OshBusinessModel.Da
{
    public class SubscribersDictionaryItemDa
    {

        public long RowNumber { get; set; }

        public int ContractId { get; set; }
        public string ContractNumber { get; set; }
        public string SubscriberName { get; set; }
        public string ContractName { get; set; }
        public string ContractAddress { get; set; }
        public string ContractTariff { get; set; }

        public double StartBalance { get; set; }
        public double BilledAmount { get; set; }
        public double PayedAmount { get; set; }
        public double EndBalance { get; set; }

        public DateTime? LastPaymentDate { get; set; }
        public DateTime? LastMetersValuesDate { get; set; }

    }
}
