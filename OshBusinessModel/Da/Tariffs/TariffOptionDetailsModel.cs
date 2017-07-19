using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OshBusinessModel.Da.Tariffs
{
    public class TariffOptionDetailsModel
    {
        public TariffOptionDetalisDa Details { get; set; }
        public TariffOptionChangesDa[] Changes { get; set; }
        public TariffOptionTariffsDa[] Tariffs { get; set; }
    }
}
