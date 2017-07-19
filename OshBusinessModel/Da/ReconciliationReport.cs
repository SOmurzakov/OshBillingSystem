using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OshBusinessModel.Da
{
    public class ReconciliationReport
    {
        public DateTime DateStart { get; set; }
        public DateTime DateEnd { get; set; }

        public ReconciliationReportItemDa[] Report { get; set; }
    }
}
