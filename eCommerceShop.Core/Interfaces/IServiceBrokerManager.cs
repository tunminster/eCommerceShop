using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eCommerceShop.Core.Interfaces
{
    public interface IServiceBrokerManager
    {
        void SendMessage<T>(T message);
        string ReceiveMessage(string queueName);
    }
}
