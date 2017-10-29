using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eCommerceShop.Core.Models
{
    public class PurchaseOrderModel
    {
        public string PurchaseOrder { get; set; }
        public string Total { get; set; }
        public int CustomerId { get; set; }
        public string Customer { get; set; }
        public List<PurchaseOrderLineItem> PurchaseOrderLineItems { get; set; }
    }

    public class PurchaseOrderLineItem
    {
        public int ProductId { get; set; }
        public string ProductName { get; set; }
    }
}
