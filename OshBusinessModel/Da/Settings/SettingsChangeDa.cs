using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OshBusinessModel.Da.Settings
{
    public class SettingsChangeDa
    {
        public int Id { get; set; }
        public string KeyName { get; set; }
        public string StringValue { get; set; }
        public int UserId { get; set; }
        public string UserName { get; set; }
        public DateTime Date { get; set; }
        public bool VisaRequired { get; set; }
        public int VisaGivenUserId { get; set; }
        public string VisaGivenUserName { get; set; }
        public DateTime? VisaGivenDate { get; set; }

        public string Description { get; set; }
    }
}
