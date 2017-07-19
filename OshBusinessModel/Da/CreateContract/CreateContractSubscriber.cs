using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;

namespace OshBusinessModel.Da.CreateContract
{
    public class CreateContractSubscriber
    {
        public int SubscriberId { get; set; }
        public DateTime RegistrationDate { get; set; }

        public string Type { get; set; }
        public string Name { get; set; }
        public string PassportNumber { get; set; }
        public string PassportWhere { get; set; }
        public string PassportDate { get; set; }
        public string AddressStreet { get; set; }
        public string AddressBuilding { get; set; }
        public string AddressFlat { get; set; }
        public string Phone { get; set; }
        public string Remarks { get; set; }

        public DateTime PassportDateAsDate
        {
            get { return DateTime.ParseExact(PassportDate, "dd.MM.yyyy", new CultureInfo("en-US")); }
        }
    }
}
