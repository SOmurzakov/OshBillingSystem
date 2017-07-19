using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Globalization;

namespace OshBusinessLogic.Helpers
{
    public static class Misc
    {
        private static CultureInfo _enCulture = new CultureInfo("en-US");

        public static string ToString(double d)
        {
            return d.ToString(_enCulture);
        }

        public static DateTime? ToDateTime(string s)
        {
            try
            {
                return
                    string.IsNullOrWhiteSpace(s)
                        ? null
                        : new DateTime?(DateTime.ParseExact(s, "dd.MM.yyyy", new CultureInfo("en-US")));
            }
            catch (Exception)
            {
                throw new Exception("Неправильный формат даты");
            }
        }

        public static double ToDouble(string s)
        {
            if (string.IsNullOrWhiteSpace(s))
            {
                return 0;
            }

            double d = 0;

            s = s.Replace(",", ".");
            
            double.TryParse(s, NumberStyles.Any, _enCulture, out d);

            return d;
        }
    }
}
