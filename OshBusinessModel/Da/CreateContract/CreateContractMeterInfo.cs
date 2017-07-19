using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OshBusinessModel.Da.CreateContract
{
    public class CreateContractMeterInfo
    {
        public string SerialNumber { get; set; }
        public string InitialValue { get; set; }

        public override string ToString()
        {
            return string.Format("{0}: {1}", SerialNumber, InitialValue);
        }
    }
}
