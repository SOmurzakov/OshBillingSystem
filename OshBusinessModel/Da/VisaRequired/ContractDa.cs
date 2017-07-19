using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OshBusinessModel.Da.VisaRequired
{
    public class ContractDa
    {

        public int ContractId { get; set; }
        public string ContractNumber { get; set; }
        public string FullAddress { get; set; }
        public string TariffId { get; set; }
        public string TariffName { get; set; }
        public int SubscriberId { get; set; }
        public string SubscriberName { get; set; }
        public int AreaId { get; set; }
        public string AreaName { get; set; }
        public int ControllerId { get; set; }
        public string ControllerName { get; set; }

    }
}
