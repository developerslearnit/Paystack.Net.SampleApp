using PaystackSampleWebApp.Models.DataModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PaystackSampleWebApp.Models.Interfaces
{
    public interface IProducts
    {
        IEnumerable<Product> GetAllProducts();
        bool AddToCart(Cart cart);
    }
}
