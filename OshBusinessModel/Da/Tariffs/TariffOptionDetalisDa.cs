using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OshBusinessModel.Da.Tariffs
{
    public class TariffOptionDetalisDa
    {
        public string SemanticId { get; set; }
        public string Name { get; set; }
        public bool Enabled { get; set; }
        public string VariableBillName { get; set; }
        public string VariableDescription { get; set; }
        public bool UsePeopleRegistered { get; set; }
        public double LitersPerDay { get; set; }
        public int ContractsCount { get; set; }
        public bool SewageAvailable { get; set; }
    }
}
