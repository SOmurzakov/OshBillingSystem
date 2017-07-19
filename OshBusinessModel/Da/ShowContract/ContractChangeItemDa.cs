using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OshBusinessModel.Da.ShowContract
{
    public class ContractChangeItemDa
    {
        public int Id { get; set; }
        public int ContractId { get; set; }
        public int ChangedUserId { get; set; }
        public DateTime ChangedDate { get; set; }
        public string ChangedUserName { get; set; }
        public string ChangeRemarks { get; set; }
        public bool VisaRequired { get; set; }
        public int VisaGivenUserId { get; set; }
        public DateTime? VisaGivenDate { get; set; }
        public string VisaGivenUserName { get; set; }

        public virtual int Weight { get { return 0; } }
        public virtual string Subcategory { get { return ""; } }

        public int Compare(ContractChangeItemDa item)
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
