﻿using eCommerceShop.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eCommerceShop.Core.Interfaces
{
    public interface IPurchaseOrderManager
    {
        bool PlaceOrder(PurchaseOrderModel purchaseOrderModel);
    }
}
