using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eCommerceShop.Data.Models
{
    public class Order
    {
        [Key]
        public int Id { get; set; }
        public string PurchaseOrder { get; set; }
        public int CustomerId { get; set; }
        public string Total { get; set; }
        public DateTime DateEntered { get; set; }

        public ICollection<OrderItem> OrderItems { get; set; }

        public Order()
        {
            this.OrderItems = new HashSet<OrderItem>();
        }
    }
}
