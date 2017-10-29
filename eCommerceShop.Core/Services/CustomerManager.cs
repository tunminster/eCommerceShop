using eCommerceShop.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using eCommerceShop.Core.Models;
using eCommerceShop.Data;
using AutoMapper;
using eCommerceShop.Data.Models;

namespace eCommerceShop.Core.Services
{
    public class CustomerManager : ICustomerManager
    {
        private readonly IEcommerceShopContext _ecommerceShopContext;

        public CustomerManager(IEcommerceShopContext ecommerceShopContext)
        {
            _ecommerceShopContext = ecommerceShopContext;
        }


        public void AddCustomer(CustomerModel customerModel)
        {
            _ecommerceShopContext.Add(Mapper.Map<Customer>(customerModel));
            _ecommerceShopContext.Commit();
        }
    }
}
