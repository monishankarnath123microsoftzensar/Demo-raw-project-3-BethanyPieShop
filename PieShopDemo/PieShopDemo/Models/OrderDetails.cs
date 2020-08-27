using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace PieShopDemo.Models
{
    public class OrderDetails
    {
        public int Id { get; set; }
        public float Amount { get; set; }
        
        public int Quantity { get; set; }
        public bool OrderConfirm { get; set; }
        public string PaymentMethod { get; set; }
        public Pies Pies { get; set; }
        public int PiesId { get; set; }
        public RegisterUser RegisterUser { get; set; }
        public int RegisterUserId { get; set; }

    }
}