using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eCommerceShop.Core.Models
{
    public class ShippingSlipModel
    {
        public string Name { get; set; }
        public string ShippingAddress { get; set; }
        public string Postcode { get; set; }
        public List<PurchaseOrderLineItem> PurchaseOrderLineItems { get; set; }
    }
}
