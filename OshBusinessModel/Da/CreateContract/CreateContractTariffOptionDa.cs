using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OshBusinessModel.Da.CreateContract
{
    public class CreateContractTariffOptionDa
    {
        public string SemanticId { get; set; }
        public string Name { get; set; }
        public string TariffSubtype { get; set; }
        public string VariableBillName { get; set; }
        public string VariableDescription { get; set; }
        public bool UsePeopleRegistered { get; set; }
        public bool SewageAvailable { get; set; }
    }
}
