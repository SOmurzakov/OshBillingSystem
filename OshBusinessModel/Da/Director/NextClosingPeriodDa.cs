using System;

namespace OshBusinessModel.Da.Director
{
    public class NextClosingPeriodDa
    {
        public DateTime NextPeriodEnd { get; set; }
        public string NextPeriodName { get; set; }
        public bool CanBeClosed { get; set; }
    }
}
