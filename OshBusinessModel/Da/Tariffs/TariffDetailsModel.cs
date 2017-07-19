using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OshBusinessModel.Da.Tariffs
{
    public class TariffDetailsModel
    {

        public TariffDictionaryDa CurrentState { get; set; }
        public TariffOptionDictionaryDa[] TariffOptions { get; set; }
        public TariffChangesDa[] Changes { get; set; }

    }
}
