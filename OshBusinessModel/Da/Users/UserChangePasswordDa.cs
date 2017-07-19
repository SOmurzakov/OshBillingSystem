using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OshBusinessModel.Da.Users
{
    public class UserChangePasswordDa : UserChangeItemDa
    {
        public override int Weight
        {
            get { return 4; }
        }
    }
}
