using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OshBusinessModel.Da.ShowContract
{
    public class ContractMeterValueDa
    {
        public int Id { get; set; }
        public int MeterId { get; set; }
        public double Value { get; set; }
        public DateTime DateAsOf { get; set; }
        public string MeterValueType { get; set; }
    }
}
