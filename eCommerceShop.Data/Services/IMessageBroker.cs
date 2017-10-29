using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eCommerceShop.Data.Services
{
    public interface IMessageBroker
    {
        void Publish<T>(T message);
        string SubscribeMessage(string queueName);
    }
}
