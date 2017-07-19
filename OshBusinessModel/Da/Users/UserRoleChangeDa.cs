using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using OshBusinessModel.Data;

namespace OshBusinessModel.Da.Users
{
    public class UserRoleChangeDa : UserChangeItemDa
    {
        public string Role { get; set; }
        public UserType UserType { get { return UserType.GetUserTypeById(Role); } }

        public override int Weight
        {
            get { return 3; }
        }
    }
}
