using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using OshBusinessModel.Da.Settings;

namespace OshBusinessLogic.Providers
{
    public class SettingsProvider
    {
        public SettingsDictionaryModel GetSetings()
        {
            var tables = NativeSql.ExecMultiple("settings_getDictionary");
            return new SettingsDictionaryModel()
                       {
                           Settings = tables[0].Rows<SettingsDa>(), 
                           LastChanges = tables[1].Rows<SettingsChangeDa>(),
                       };
        }

        public SettingsDetailsModel GetSettingsDetails(string key)
        {
            var tables = NativeSql.ExecMultiple("settings_getDetails", new {key,});
            return new SettingsDetailsModel()
                       {
                           Details = tables[0].OneRow<SettingsDa>(),
                           Changes = tables[1].Rows<SettingsChangeDa>(),
                       };
        }

        public Dictionary<string, string> GetAsDictionary()
        {
            var settings = NativeSql.Exec("settings_getAsDictionary").Rows<ShortSettingsItem>();
            return settings.ToDictionary(key => key.KeyName, value => value.StringValue);
        }

        public bool SetNewValue(string key, string value, int userId)
        {
            try
            {
                NativeSql.Exec("settings_setNewValue", new {key, value, userId, });
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public void VisaApprove(int changeId, int userId)
        {
            NativeSql.Exec("settings_visaApprove", new {changeId, userId,});
        }

        public void VisaDecline(int changeId, int userId)
        {
            NativeSql.Exec("settings_visaDecline", new {changeId, userId,});
        }

    }
}
