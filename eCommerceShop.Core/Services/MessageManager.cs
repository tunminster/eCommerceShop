using eCommerceShop.Common.Helpers;
using eCommerceShop.Core.Interfaces;
using eCommerceShop.Core.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eCommerceShop.Core.Services
{
    public class MessageManager : IMessageManager,IDisposable
    {
        private readonly IServiceBrokerManager _serviceBrokerManager;
        private readonly IPurchaseOrderManager _purchaseOrderManager;
        private bool _isRunning;
        private static readonly log4net.ILog log =
            log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        public MessageManager(IServiceBrokerManager serviceBrokerManager, IPurchaseOrderManager purchaseOrderManager)
        {
            _serviceBrokerManager = serviceBrokerManager;
            _purchaseOrderManager = purchaseOrderManager;
        }

        public void DoProcess()
        {
            try
            {
                _isRunning = true;
                log.Info("Message Manager process started.");
                var result = _serviceBrokerManager.ReceiveMessage(ConfigHelper.ServiceBrokerQueue);

                if (string.IsNullOrEmpty(result)) return;

                var purchaseOrderModel = JsonConvert.DeserializeObject<PurchaseOrderModel>(result);

                log.Info($"PurchaseOrderManager called with message {result}");
                _purchaseOrderManager.PlaceOrder(purchaseOrderModel);

            }
            catch(Exception ex)
            {
                log.Error(ex);
            }
            finally
            {
                _isRunning = false;
            }
        }

        public bool IsProcessRunning()
        {
            return _isRunning;
        }

        public void Dispose()
        {
            this.Dispose(true);            
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if(disposing)
            {
                GC.Collect();
            }
        }
    }
}
