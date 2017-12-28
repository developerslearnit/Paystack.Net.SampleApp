using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PaystackSampleWebApp.Models.ViewModels
{
    public class CartViewModel
    {
        public int productId { get; set; }
        public string productName { get; set; }
        public string productImage { get; set; }
        public decimal price { get; set; }
        public int quantity { get; set; }
        public decimal totalAmount { get { return quantity * price; } }
    }
}