using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using OshBusinessModel.Da.Areas;
using OshBusinessModel.Da.CreateContract;

namespace OshBusinessModel.Da
{
    public class CreateContractModelDa
    {

        public AreasDictionaryDa[] Areas { get; set; }
        public CreateContractTariffDa[] Tariffs { get; set; }
        public CreateContractSubscriber Subscriber { get; set; }

    }
}
