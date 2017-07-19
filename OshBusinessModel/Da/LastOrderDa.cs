using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OshBusinessModel.Da
{
    public class LastOrderDa
    {
        public int Id { get; set; }
        public DateTime DateStart { get; set; }
        public DateTime DateEnd { get; set; }
        public string Type { get; set; }
        public string Remarks { get; set; }
        public int UserId { get; set; }
        public bool IsOpen { get; set; }
        public string Operation { get; set; }

        public int AllContracts { get; set; }
        public int BilledAtAll { get; set; }

        public int ContractsWithMetersCount { get; set; }
        public int BilledContractsCount { get; set; }

        public int ProgressClosing
        {
            get { return ContractsWithMetersCount == 0 ? 100 : BilledContractsCount*100/ContractsWithMetersCount; }
        }

        public int ProgressCreating
        {
            get
            {
                return (AllContracts - ContractsWithMetersCount) <= 0
                           ? 100
                           : BilledAtAll*100/(AllContracts - ContractsWithMetersCount);
            }
        }
    }
}
