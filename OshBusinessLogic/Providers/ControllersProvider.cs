using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using OshBusinessModel.Da;
using OshBusinessModel.Da.Controller;

namespace OshBusinessLogic.Providers
{
    public class ControllersProvider
    {
        public ControllerBriefDa GetBrief(int controllerId)
        {
            return NativeSql.Exec("controller_getBrief", new {controllerId}).OneRow<ControllerBriefDa>();
        }

        public ControllerRootingsDa[] GetRootings(int userId)
        {
            return NativeSql.Exec("controller_getRootings", new {userId}).Rows<ControllerRootingsDa>();
        }

    }
}
