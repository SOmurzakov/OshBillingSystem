using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OshBusinessModel.Da.Settings
{
    public class SettingsDictionaryModel
    {
        public SettingsDa[] Settings { get; set; }
        public SettingsChangeDa[] LastChanges { get; set; }
    }
}
