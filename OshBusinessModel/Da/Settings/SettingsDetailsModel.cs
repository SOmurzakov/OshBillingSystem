using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OshBusinessModel.Da.Settings
{
    public class SettingsDetailsModel
    {
        public SettingsDa Details { get; set; }
        public SettingsChangeDa[] Changes { get; set; }
    }
}
