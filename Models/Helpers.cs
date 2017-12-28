using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PaystackSampleWebApp.Models
{
    public static class Helpers
    {
        public static string CalcTotalPrice(int qty,decimal price)
        {
            return ((decimal)qty * price).ToString("#,##.00");
        }
    }
}