using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using OshBusinessModel.Data;

namespace OshBusinessModel.Da.Users
{
    public class UserActionDa : UserChangeItemDa
    {
        public string Action { get; set; }
        public string Remarks { get; set; }

        public override int Weight
        {
            get { return 1; }
        }

        public UserAction UserAction {get { return UserAction.GetById(Action); }}
    }
}
