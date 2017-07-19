using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OshBusinessModel.Da.Controller
{
    public class ControllerRootingsDa
    {
        public int ContractId { get; set; }
        public string ContractNumber { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string Phone { get; set; }
        public string Result { get; set; }
        public bool Billed { get; set; }
    }
}
