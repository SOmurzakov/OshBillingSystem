using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using OshBusinessLogic.Helpers;

namespace OshChannel.Models
{
    public class RegisterTransactionModel
    {
        public int SubagentId { get; set; }
        public double Amount { get; set; }
        public int ContractId { get; set; }
    }

    public class CreateSubagentAjaxModel
    {
        public string Name { get; set; }
        public string Remarks { get; set; }
        public int HasBalance { get; set; }
        public string CurrentBalance { get; set; }

        public double RightCurrentBalance { get { return HasBalance > 0 ? Misc.ToDouble(CurrentBalance) : 0; }}
    }

    public class RegisterPopupAjaxModel
    {
        public int SubagentId { get; set; }
        public string Amount { get; set; }
        public string Remarks { get; set; }
    }

    public class ChangeInfoAjaxModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
}