using eCommerceShop.Core.Interfaces;
using eCommerceShop.Core.Models;
using eCommerceShop.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace eCommerceShop.Web.Controllers
{
    [Authorize]
    public class OrderController : Controller
    {
        private readonly IServiceBrokerManager _serviceBrokerManager;

        public OrderController(IServiceBrokerManager serviceBrokerManager)
        {
            _serviceBrokerManager = serviceBrokerManager;
        }

        // GET: Order
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Index(OrderViewModel model)
        {
            if(ModelState.IsValid)
            {
                var purchaseOrder = new PurchaseOrderModel();
                purchaseOrder.Customer = User.Identity.Name;
                var radom = new Random();
                purchaseOrder.PurchaseOrder = radom.Next(0, 9).ToString();
                purchaseOrder.Total = purchaseOrder.Total;
                purchaseOrder.PurchaseOrderLineItems = new List<PurchaseOrderLineItem>();
                AddProducts(model, purchaseOrder);

                _serviceBrokerManager.SendMessage(purchaseOrder);

                return RedirectToAction("thank");
            }
            return View(model);
        }

        public ActionResult Thank()
        {
            return View();
        }


        private static void AddProducts(OrderViewModel model, PurchaseOrderModel purchaseOrder)
        {
            purchaseOrder.PurchaseOrderLineItems.Add(new PurchaseOrderLineItem()
            {
                ProductId = model.BookProduct,
                ProductName = model.BookProductName,
            });

            purchaseOrder.PurchaseOrderLineItems.Add(new PurchaseOrderLineItem()
            {
                ProductId = model.VideoProduct,
                ProductName = model.VideoProductName,
            });

            purchaseOrder.PurchaseOrderLineItems.Add(new PurchaseOrderLineItem()
            {
                ProductId = model.MembershipProduct,
                ProductName = model.MembershipProductName,
            });
        }
    }
}