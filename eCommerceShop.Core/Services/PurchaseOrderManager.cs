using eCommerceShop.Common.Helpers;
using eCommerceShop.Core.Interfaces;
using eCommerceShop.Core.Models;
using eCommerceShop.Data;
using eCommerceShop.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eCommerceShop.Core.Services
{
    public class PurchaseOrderManager : IPurchaseOrderManager
    {
        private readonly IEcommerceShopContext _context;

        public PurchaseOrderManager(IEcommerceShopContext context)
        {
            _context = context;
        }

        /// <summary>
        ///  Place order
        /// </summary>
        /// <param name="purchaseOrderModel"></param>
        /// <returns></returns>
        public bool PlaceOrder(PurchaseOrderModel purchaseOrderModel)
        {
            var isBookClubMember = false;
            var isVideoClubMember = false;

            var customer = _context.FindBy<Customer>(x => x.Email == purchaseOrderModel.Customer).FirstOrDefault();
            purchaseOrderModel.CustomerId = customer.Id;

            var order = new Order
            {
                PurchaseOrder = purchaseOrderModel.PurchaseOrder,
                Total = purchaseOrderModel.Total,
                CustomerId = purchaseOrderModel.CustomerId,
                DateEntered = DateTime.Now
            };

            foreach (var item in purchaseOrderModel.PurchaseOrderLineItems)
            {
                if (item.ProductId == ConfigHelper.BookClubMembership) isBookClubMember = true;
                if (item.ProductId == ConfigHelper.VideoClubMembership) isVideoClubMember = true;

                order.OrderItems.Add(new OrderItem()
                {
                    ProductId = item.ProductId,
                    DateEntered = DateTime.Now,
                    OrderId = order.Id
                });
            }

            _context.Add<Order>(order);
            _context.Commit();

            DoBookClubMember(purchaseOrderModel, isBookClubMember);

            DoVideoClubMember(purchaseOrderModel, isVideoClubMember);

            return true;
        }

        /// <summary>
        /// Do Video club member if membership has purchased.
        /// </summary>
        /// <param name="purchaseOrderModel"></param>
        /// <param name="isVideoClubMember"></param>
        private void DoVideoClubMember(PurchaseOrderModel purchaseOrderModel, bool isVideoClubMember)
        {
            if (isVideoClubMember)
            {
                var customer = _context.FindBy<Customer>(x => x.Id == purchaseOrderModel.CustomerId).FirstOrDefault();
                customer.IsVideoClubMembership = true;

                _context.Edit(customer);
                _context.Commit();
            }
        }

        /// <summary>
        /// Do book club member if membership has purchased.
        /// </summary>
        /// <param name="purchaseOrderModel"></param>
        /// <param name="isBookClubMember"></param>
        private void DoBookClubMember(PurchaseOrderModel purchaseOrderModel, bool isBookClubMember)
        {
            if (isBookClubMember)
            {
                var customer = _context.FindBy<Customer>(x => x.Id == purchaseOrderModel.CustomerId).FirstOrDefault();
                customer.IsBookClubMembership = true;

                _context.Edit(customer);
                _context.Commit();
            }
        }
    }
}
