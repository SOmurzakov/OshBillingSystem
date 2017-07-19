using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OshBusinessModel.Da.Users
{
    public class UserChangeItemDa
    {
        public int ChangedByUserId { get; set; }
        public DateTime ChangedDate { get; set; }
        public string ChangedByName { get; set; }

        public virtual int Weight { get { return 0; } }
        public int Compare(UserChangeItemDa item)
        {
            if (ChangedDate == item.ChangedDate)
            {
                if (Weight == item.Weight)
                {
                    return 0;
                }
                else
                {
                    return Weight < item.Weight
                               ? 1
                               : -1;
                }
            }
            else
            {
                return ChangedDate < item.ChangedDate
                           ? 1
                           : -1;
            }
        }
    }
}
