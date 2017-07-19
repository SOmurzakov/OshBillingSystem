using System.Collections.Generic;
using System.Web;
using OshBusinessLogic.Providers;

namespace OshChannel.Helpers
{
    public static class Settings
    {
        public static string Get(string key)
        {
            var items = HttpContext.Current.Items;

            if (!items.Contains("Settings"))
            {
                items.Add("Settings", new SettingsProvider().GetAsDictionary());
            }

            var settings = (Dictionary<string, string>) items["Settings"];

            return settings[key];
        }
    }
}