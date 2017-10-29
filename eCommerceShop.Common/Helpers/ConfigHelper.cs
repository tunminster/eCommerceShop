using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eCommerceShop.Common.Helpers
{
    public class ConfigHelper : HelperBase
    {
        public static string ServiceBrokerConnection
        {
            get { return GetAppSettingsValue<string>("ServiceBrokerConnection", string.Empty); }
        }

        public static string ServiceBrokerMessageType
        {
            get { return GetAppSettingsValue<string>("ServiceBrokerMessageType", string.Empty); }
        }

        public static string ServiceBrokerContract
        {
            get { return GetAppSettingsValue<string>("ServiceBrokerContract", string.Empty); }
        }

        public static string ServiceBrokerSfService
        {
            get { return GetAppSettingsValue<string>("ServiceBrokerSfService", string.Empty); }
        }

        public static string ServiceBrokerService
        {
            get { return GetAppSettingsValue<string>("ServiceBrokerService", string.Empty); }
        }

        public static string ServiceBrokerQueue
        {
            get { return GetAppSettingsValue<string>("ServiceBrokerQueue", string.Empty); }
        }

        public static int BookClubMembership
        {
            get { return GetAppSettingsValue<int>("BookClubMembership", 3); }
        }

        public static int VideoClubMembership
        {
            get { return GetAppSettingsValue<int>("VideoClubMembership", 4); }
        }
    }
}
