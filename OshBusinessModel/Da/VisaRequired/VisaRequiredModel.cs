using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OshBusinessModel.Da.VisaRequired
{
    public class VisaRequiredModel
    {
        public ContractDa[] Contracts { get; set; }
        public SubscriberDa[] Subscribers { get; set; }
        public SettingsDa[] Settings { get; set; }
    }
}
