using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PaystackSampleWebApp.Models.ViewModels
{
    public class PaystackCustomerModel
    {
        public string firstName { get; set; }
        public string lastName { get; set; }
        public string email { get; set; }
        public string phone { get; set; }
        public int amount { get; set; }
    }
}