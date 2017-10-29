using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace eCommerceShop.Web.Models
{
    public class OrderViewModel
    {
        public int BookProduct { get; set; }
        public int VideoProduct { get; set; }
        public int MembershipProduct { get; set; }

        public string BookProductName { get; set; }
        public string VideoProductName { get; set; }
        public string MembershipProductName { get; set; }
    }
}