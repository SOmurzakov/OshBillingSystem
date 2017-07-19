using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OshBusinessModel.Da.Users
{
    public class UserDetailsModel
    {
        public UserDetailsDa Details { get; set; }
        public UserActionDa[] Actions { get; set; }
        public UserDetailsChangeDa[] DetailsChanges { get; set; }
        public UserRoleChangeDa[] Roles { get; set; }
        public UserChangePasswordDa[] PasswordChanges { get; set; }

        public UserChangeItemDa[] Changings
        {
            get 
            {
                List<UserChangeItemDa> changings = new List<UserChangeItemDa>();

                changings.AddRange(Actions);
                changings.AddRange(DetailsChanges);
                changings.AddRange(Roles);
                changings.AddRange(PasswordChanges);

                changings.Sort((daA, daB) => daA.Compare(daB));

                return changings.ToArray();
            }
        }
    }
}
