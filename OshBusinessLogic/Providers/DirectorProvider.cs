using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using OshBusinessModel.Da.Director;
using OshBusinessModel.Da.VisaRequired;

namespace OshBusinessLogic.Providers
{
    public class DirectorProvider
    {
        public DirectorIndexModel GetIndexModel()
        {
            var tables = NativeSql.ExecMultiple("director_getIndexModel");

            return new DirectorIndexModel()
                       {
                           NextClosingPeriod = tables[0].OneRow<NextClosingPeriodDa>(),
                       };
        }

        public VisaRequiredModel GetVisaRequiredItems()
        {
            var tables = NativeSql.ExecMultiple("director_getVisaRequiredItems");
            var model = new VisaRequiredModel()
                            {
                                Contracts = tables[0].Rows<ContractDa>(),
                                Subscribers = tables[1].Rows<SubscriberDa>(),
                                Settings = tables[2].Rows<SettingsDa>(),
                            };

            return model;
        }
    }
}
