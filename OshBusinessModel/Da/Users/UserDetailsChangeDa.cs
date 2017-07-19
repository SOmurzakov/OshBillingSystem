using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OshBusinessModel.Da.Users
{
    public class UserDetailsChangeDa : UserChangeItemDa
    {
        public string Name { get; set; }
        public string Address { get; set; }
        public string Passport { get; set; }
        public string Phone { get; set; }

        public override int Weight
        {
            get { return 2; }
        }
    }
}
