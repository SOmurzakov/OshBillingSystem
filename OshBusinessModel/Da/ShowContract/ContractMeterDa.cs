using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OshBusinessModel.Da.ShowContract
{
    public class ContractMeterDa
    {
        public int MeterId { get; set; }
        public string SerialNumber { get; set; }
        public double MeterValue { get; set; }
        public bool Enabled { get; set; }
        public DateTime ValueDateAsOf { get; set; }
        public string MeterValueType { get; set; }
    }
}
