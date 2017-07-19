using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OshBusinessModel.Da.Rootings
{
    public class RootingsBuildingsModel
    {
        public int AreaId { get; set; }
        public string AreaName { get; set; }
        public string AddressStreet { get; set; }

        public RootingsBuildingsDa[] Buildings { get; set; }
    }
}
