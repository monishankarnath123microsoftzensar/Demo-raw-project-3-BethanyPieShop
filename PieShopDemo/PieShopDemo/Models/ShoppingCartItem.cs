using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PieShopDemo.Models
{
    public class ShoppingCartItem
    {
        public int Id { get; set; }
        public float AmountToPay { get; set; }
        public OrderDetails OrderDetails { get; set; }
        public int OrderDetailsId { get; set; }
    }
}