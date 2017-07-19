using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using OshBusinessModel.Da.Bills;

namespace OshBusinessModel.Da.Subscribers
{
    public class SubscriberDetailsModel
    {
        public SubscriberDetailsDa Details { get; set; }
        public SubscriberChangeDa[] Changes { get; set; }
        public SubscriberContractDa[] Contracts { get; set; }
        public Bill[] Bills { get; set; }
    }
}
