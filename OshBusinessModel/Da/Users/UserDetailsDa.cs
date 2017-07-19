using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using OshBusinessModel.Data;

namespace OshBusinessModel.Da.Users
{
    public class UserDetailsDa
    {
        public int UserId { get; set; }
        public string Login { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string Passport { get; set; }
        public string Phone { get; set; }
        public string Role { get; set; }
        public bool Enabled { get; set; }
        public string Remarks { get; set; }

        public UserType UserType { get { return UserType.GetUserTypeById(Role); } }
    }
}
