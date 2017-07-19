using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OshBusinessModel.Da
{
    public class SubagentsDictionaryDa
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Remarks { get; set; }
        public string SemanticId { get; set; }
        public bool HasBalance { get; set; }
        public double CurrentBalance { get; set; }
        public bool Enabled { get; set; }
    }
}
