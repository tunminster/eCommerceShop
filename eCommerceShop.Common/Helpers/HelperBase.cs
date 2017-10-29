  using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eCommerceShop.Common.Helpers
{
    public class HelperBase
    {
        public static T GetAppSettingsValue<T>(string appSettingsKey, T defaultValue)
        {
            if (ConfigurationManager.AppSettings[appSettingsKey] == null)
                return defaultValue;
            else
                return (T)Convert.ChangeType(ConfigurationManager.AppSettings[appSettingsKey], typeof(T));
        }
    }
}
