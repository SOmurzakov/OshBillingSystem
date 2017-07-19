using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OshBusinessModel.Da.Bills
{
    public class BillMeterDa
    {
        public int BillMeterId { get; set; }
        public int BillId { get; set; }
        public int MeterId { get; set; }
        public int MeterLastValueId { get; set; }
        public int MeterValueId { get; set; }
        public double CubicMeters { get; set; }

        public double MeterLastValue { get; set; }
        public DateTime MeterLastValueDate { get; set; }
        public string LastMeterValueType { get; set; }

        public double MeterValue { get; set; }
        public DateTime MeterValueDate { get; set; }
        public string MeterValueType { get; set; }
    }
}
