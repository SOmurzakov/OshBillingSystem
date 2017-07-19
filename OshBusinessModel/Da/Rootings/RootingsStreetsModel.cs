using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using OshBusinessModel.Da;
using OshBusinessModel.Da.Areas;

namespace OshBusinessModel.Da.Rootings
{
    public class RootingsStreetsModel
    {
        public int AreaId { get; set; }
        public string AreaName { get; set; }
        public int ControllerId { get; set; }
        public UserDa[] Controllers { get; set; }
        public AreasDictionaryDa[] Areas { get; set; }
        public RootingsStreetsDa[] Streets { get; set; }
    }
}
