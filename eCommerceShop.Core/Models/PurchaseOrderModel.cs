using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eCommerceShop.Core.Models
{
    public class PurchaseOrderModel
    {
        public string OrderId { get; set; }
        public string Total { get; set; }
        public int CustomerId { get; set; }
    }

    public class PurchaseOrderLineItem
    {
        public string ProductNmae { get; set; }
    }
}
