﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OshBusinessModel.Da.CreateContract
{
    public class CreateContractSubscriberDa
    {
        public DateTime RegistrationDate { get; set; }
        public int SubscriberId { get; set; }
        public string Name { get; set; }
        public string Type { get; set; }
        public string PassportNumber { get; set; }
        public string PassportWhere { get; set; }
        public DateTime? PassportDate { get; set; }
        public string AddressStreet { get; set; }
        public string AddressBuilding { get; set; }
        public string AddressFlat { get; set; }
        public string Phone { get; set; }
        public string Remarks { get; set; }
        public string Inn { get; set; }
        public string Ugkns { get; set; }
        public string Mfo { get; set; }
        public bool InvoiceRequired { get; set; }
        public string UgknsName { get; set; }
        public string BankCode { get; set; }
        public string BankName { get; set; }
        public string BankAccount { get; set; }

        public string PassportDateAsString
        {
            get { return PassportDate != null ? PassportDate.Value.ToShortDateString() : ""; }
        }
    }
}
