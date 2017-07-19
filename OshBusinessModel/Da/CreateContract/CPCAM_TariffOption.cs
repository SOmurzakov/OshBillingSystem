using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OshBusinessModel.Da.CreateContract
{
    public class CPCAM_TariffOption
    {
        public string SemanticId { get; set; }
        public string Value { get; set; }
        public bool Sewage { get; set; }

        public override string ToString()
        {
            return string.Format("{0}: {1}", SemanticId, Value);
        }
    }
}
