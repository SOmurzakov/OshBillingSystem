using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using OshBusinessModel.Da.Areas;

namespace OshBusinessModel.Da.CreateContract
{
    public class CreateContractModel
    {
        public AreasDictionaryDa[] Areas { get; set; }
        public CreateContractSubscriberDa Subscriber { get; set; }

        public CreateContractTariffDa[] Tariffs { get; set; }
        public CreateContractTariffOptionDa[] Options { get; set; }

        public string[] Streets { get; set; }
    }
}
