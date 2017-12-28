using PaystackSampleWebApp.Models.DataModel;
using PaystackSampleWebApp.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace PaystackSampleWebApp.Models.Interfaces
{
    public interface ICart
    {
        IEnumerable<Cart> GetCartItems();

        Cart GetCartItem(long itemId);
       
        bool AddToCart(Cart cart);

        string GetCartId(HttpContextBase context);

        IEnumerable<CartViewModel> GetUserCartItems(string cartId);
    }
}
