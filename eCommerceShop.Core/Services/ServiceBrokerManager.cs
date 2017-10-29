using eCommerceShop.Core.Interfaces;
using eCommerceShop.Data.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eCommerceShop.Core.Services
{
    public class ServiceBrokerManager : IServiceBrokerManager
    {
        private readonly IMessageBroker _messageBroker;
        private static readonly log4net.ILog log =
            log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        public ServiceBrokerManager(IMessageBroker messageBroker)
        {
            _messageBroker = messageBroker;
        }

        public string ReceiveMessage(string queueName)
        {
            log.Info("Message received:");
            log.Info(queueName);
            return _messageBroker.SubscribeMessage(queueName);
        }

        public void SendMessage<T>(T message)
        {
            log.Info("Message Sent:");
            log.Info(message);
            _messageBroker.Publish(message);
        }
    }
}
