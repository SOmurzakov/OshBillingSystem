using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using OshBusinessModel.Data;

namespace OshBusinessModel.Da.Users
{
    public class UserDictionaryDa
    {
        public int UserId { get; set; }
        public string Name { get; set; }
        public string Phone { get; set; }
        public string Role { get; set; }
        public bool Enabled { get; set; }
        public string Remarks { get; set; }

        public UserType UserType { get { return UserType.GetUserTypeById(Role); } }
        public string RemarksCombined
        {
            get 
            { 
                string blocked = !Enabled ? "Заблокирован" : "";

                return string.Format("{0} {1}", blocked, Remarks).Trim();
            }
        }
    }
}
