using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OshBusinessModel.Da.Subscribers
{
    public class SubscriberContractDa
    {
        public int ContractId { get; set; }
        public int ArchiveId { get; set; }
        public int SubscriberId { get; set; }
        public string ContractName { get; set; }
        public int AreaId { get; set; }
        public string TariffId { get; set; }
        public string TariffName { get; set; }
        public string FullAddress { get; set; }
        public bool IsOpen { get; set; }
        public string ContractNumber { get; set; }
        public string AreaName { get; set; }
        public int ControllerId { get; set; }
        public string ControllerName { get; set; }
    }
}
