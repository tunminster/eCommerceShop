using eCommerceShop.Common.Helpers;
using eCommerceShop.Common.Utils;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eCommerceShop.Data.Services
{
    public class ServiceMessageBroker : IMessageBroker
    {
        private readonly string _connectionString = ConfigHelper.ServiceBrokerConnection;
        private readonly string _messageType = ConfigHelper.ServiceBrokerMessageType;
        private readonly string _contract = ConfigHelper.ServiceBrokerContract;
        private readonly string _purchaseOrderService = ConfigHelper.ServiceBrokerService;
        private readonly string _messageSenderService = ConfigHelper.ServiceBrokerSfService;
        private static readonly log4net.ILog log =
            log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        public void Publish<T>(T message)
        {
            using (var sqlConnection = new SqlConnection(_connectionString))
            {
                sqlConnection.Open();
                using (var sqlTransaction = sqlConnection.BeginTransaction())
                {
                    try
                    {
                        var conversationHandle = ServiceBrokerWrapper.BeginConversation(sqlTransaction,
                            _messageSenderService, _purchaseOrderService, _contract);

                        string json = JsonConvert.SerializeObject(message);

                        ServiceBrokerWrapper.Send(sqlTransaction, conversationHandle, _messageType,
                            ServiceBrokerWrapper.GetBytes(json));

                        ServiceBrokerWrapper.EndConversation(sqlTransaction, conversationHandle);

                        sqlTransaction.Commit();
                    }
                    catch (Exception ex)
                    {
                        sqlTransaction.Rollback();
                        log.Error(ex);
                    }

                }
                sqlConnection.Close();

            }
        }

        public string SubscribeMessage(string queueName)
        {
            using (var sqlConnection = new SqlConnection(_connectionString))
            {
                sqlConnection.Open();
                var result = string.Empty;
                using (var sqlTransaction = sqlConnection.BeginTransaction())
                {
                    try
                    {
                        var rawMessage = ServiceBrokerWrapper.WaitAndReceive(sqlTransaction, queueName, 10 * 1000);

                        if (rawMessage != null && rawMessage.Body.Length > 0)
                        {
                            result = ServiceBrokerWrapper.GetString(rawMessage.Body);
                        }
                        sqlTransaction.Commit();
                    }
                    catch (Exception ex)
                    {
                        sqlTransaction.Rollback();
                        log.Error(ex);
                    }
                }
                sqlConnection.Close();

                return result;
            }
        }
    }
}
