using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OshBusinessModel.Da.Bills
{
    public class BillContractDetailsDa
    {
        public int ContractId { get; set; }
        public int SubscriberId { get; set; }
        public string ContractName { get; set; }
        public string FullAddress { get; set; }
        public string ContractNumber { get; set; }
        public string Phone { get; set; }
        public int AreaId { get; set; }
        public string Type { get; set; }
        public string Name { get; set; }
        public string PassportNumber { get; set; }
        public string PassportWhere { get; set; }
        public DateTime PassportDate { get; set; }
        public string Inn { get; set; }
        public string Ugkns { get; set; }
        public string Mfo { get; set; }
        public string SubscriberFullAddress { get; set; }
        public string SubscriberPhone { get; set; }
        public string AreaName { get; set; }
        public int ControllerId { get; set; }
        public string ControllerName { get; set; }

        public bool IsLegalEntity { get { return Type != "prs"; }}
    }
}
