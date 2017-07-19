using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using OshBusinessModel.Da.Areas;

namespace OshBusinessModel.Da.Rootings
{
    public class RootingsForControllerModel
    {
        public int PeriodId { get; set; }
        public ShortBillingDa[] Periods { get; set; }

        public int ControllerId { get; set; }
        public UserDa[] Controllers { get; set; }

        public int AreaId { get; set; }
        public AreasDictionaryDa[] Areas { get; set; }

        public RootingContractForControllerDa[] Contracts { get; set; }
    }
}
