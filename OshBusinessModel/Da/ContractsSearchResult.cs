using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OshBusinessModel.Da
{
    public class ContractsSearchResult
    {
        public string Key { get; set; }
        public string Street { get; set; }
        public string Building { get; set; }
        public string Appartment { get; set; }
        public string Area { get; set; }
        public string ContractName { get; set; }
        public string ControllerName { get; set; }
        public string Bill { get; set; }

        public ContractSearchResultDa[] Contracts { get; set; }
        public SubscriberSearchResultDa[] Subscribers { get; set; }
        public string[] Streets { get; set; }
        public bool HideLinkToDictionary { get; set; }

        public bool SearchByKey { get { return !string.IsNullOrWhiteSpace(Key); } }
        public bool SearchByBill {get { return !string.IsNullOrWhiteSpace(Bill);  }}
    }
}
