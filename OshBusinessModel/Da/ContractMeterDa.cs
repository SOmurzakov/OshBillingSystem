using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OshBusinessModel.Da
{
    public class ContractMeterDa
    {
        public int ContractId { get; set; }
        public int MeterId { get; set; }
        public string MeterSerialNumber { get; set; }
        public string MeterRemarks { get; set; }
        public double MeterValue { get; set; }
        public bool MeterSetByAverage { get; set; }
    }
}
