using eCommerceShop.Core.Interfaces;
using eCommerceShop.Core.Services;
using eCommerceShop.Data;
using eCommerceShop.Data.Services;
using Ninject;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Reflection;
using System.ServiceProcess;
using System.Text;
using System.Threading.Tasks;
using Topshelf;

namespace eCommerShop.WindowService
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        static void Main(string[] args)
        {
            ServiceBase[] ServicesToRun;
            var kernel = new StandardKernel();
            kernel.Load(Assembly.GetExecutingAssembly());
            kernel.Bind<IEcommerceShopContext>().To<EcommerceShopContext>();

            kernel.Bind<IMessageManager>().To<MessageManager>();
            kernel.Bind<IPurchaseOrderManager>().To<PurchaseOrderManager>();
            kernel.Bind<IServiceBrokerManager>().To<ServiceBrokerManager>();
            kernel.Bind<ICustomerManager>().To<CustomerManager>();

            kernel.Bind<IMessageBroker>().To<ServiceMessageBroker>();
            var messageManager = kernel.Get<MessageManager>();

            //ServicesToRun = new ServiceBase[]
            //{
            //    new MessageService(messageManager)
            //};
            //ServiceBase.Run(ServicesToRun);

            HostFactory.Run(x =>
            {
                //IMessageManager messageManager = kernel.Get<MessageManager>();
                x.Service<MessageService>(s =>
                {
                    s.ConstructUsing(n => new MessageService(messageManager));
                    s.WhenStarted(service => service.Start(args));
                    s.WhenStopped(service => service.Stop());
                });

                string serviceName = ConfigurationManager.AppSettings["ServiceName"];
                //x.RunAs(ConfigurationManager.AppSettings["ServiceAccountUser"], ConfigurationManager.AppSettings["ServiceAccountPwd"]);
                x.SetServiceName(serviceName);
                x.SetDisplayName(serviceName);
                x.SetDescription(serviceName);

                x.StartAutomaticallyDelayed();

                if (ServiceConfig.IsTestMode)
                    x.RunAsPrompt();

            });

        }
    }
}
