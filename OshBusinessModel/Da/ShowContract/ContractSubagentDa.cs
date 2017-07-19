using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OshBusinessModel.Da.ShowContract
{
    public class ContractSubagentDa
    {
        public int SubagentId { get; set; }
        public string SubagentName { get; set; }
        public bool HasBalance { get; set; }
        public bool IsSystem { get; set; }
        public string SemanticId { get; set; }
    }
}
