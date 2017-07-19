using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OshBusinessLogic.Providers
{
    public class DebugProvider
    {
        public void ClearBilling()
        {
            NativeSql.Exec("debug_clearBilling");
        }
    }
}
