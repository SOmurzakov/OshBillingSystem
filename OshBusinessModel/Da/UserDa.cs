using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OshBusinessModel.Da
{
    public partial class UserDa
    {
        public int UserId { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string Passport { get; set; }
        public string Phone { get; set; }
        public string Role { get; set; }
        public bool Enabled { get; set; }
        public string Remarks { get; set; }
    }
}
