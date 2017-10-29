using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eCommerShop.WindowService
{
    internal static class ServiceConfig
    {
        internal static int TimerInterval => int.Parse(ConfigurationManager.AppSettings["TimeInterval"]);
        internal static int WakeUpInterval => 1000 * 60; // 1 minute
        internal static bool IsTestMode => bool.Parse(ConfigurationManager.AppSettings["IsTestMode"]);
    }
}
