using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OshBusinessModel.Da
{
    public class ContractSearchResultDa
    {
        public int ContractId { get; set; }
        public string ContractStringId { get; set; }
        public int SubscriberId { get; set; }
        public string Name { get; set; }
        public string ControllerName { get; set; }
        public string Address { get; set; }
        public string Phone { get; set; }
        public string TariffName { get; set; }
        public int PeopleRegistered { get; set; }
        public double EndBalance { get; set; }
        public DateTime LastBilledDate { get; set; }
        public int SortId1 { get; set; }
        public int SortId2 { get; set; }

    }
}
