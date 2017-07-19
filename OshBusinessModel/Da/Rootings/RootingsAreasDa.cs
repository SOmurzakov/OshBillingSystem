using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OshBusinessModel.Da.Rootings
{
    public class RootingsAreasDa
    {
        public int AreaId { get; set; }
        public string AreaName { get; set; }

        public int OpenContractsCount { get; set; }
        public int ContractsWithMetersCount { get; set; }
        public int NoMetersValuesProvidedCount { get; set; }
    }
}
