using PaystackSampleWebApp.Models.DataModel;
using PaystackSampleWebApp.Models.Interfaces;
using PaystackSampleWebApp.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PaystackSampleWebApp.Models.Repository
{
    public class CartRepository : BaseRepository<ShoppingCartEntities>, ICart
    {
        public bool AddToCart(Cart cart)
        {
            var existingItem = DataContext.Carts.Where(x => x.ProductId == cart.ProductId);
            if (existingItem.Any())
            {
                existingItem.First().Count += 1;
                DataContext.SaveChanges();
                return true;
            }
            else
            {

                DataContext.Carts.Add(cart);

                return DataContext.SaveChanges() > 0;
            }

        }

        public Cart GetCartItem(long itemId)
        {

            return DataContext.Carts.FirstOrDefault(x => x.RecordId == itemId);
        }

        public IEnumerable<Cart> GetCartItems()
        {
            return DataContext.Carts;
        }


        public string GetCartId(HttpContextBase context)
        {
            if (context.Request.Cookies["CartId"] == null)
            {
                if (!string.IsNullOrWhiteSpace(context.User.Identity.Name))
                {
                    HttpCookie aCookie = new HttpCookie("CartId");
                    aCookie.Value = context.User.Identity.Name;
                    aCookie.Expires = DateTime.Now.AddDays(4);
                    context.Response.Cookies.Add(aCookie);
                }
                else
                {
                    Guid tempCartId = Guid.NewGuid();
                    HttpCookie aCookie = new HttpCookie("CartId");
                    aCookie.Value = tempCartId.ToString();
                    aCookie.Expires = DateTime.Now.AddDays(4);
                    context.Response.Cookies.Add(aCookie);

                }
            }

            var fCookie = context.Request.Cookies["CartId"];

            return context.Request.Cookies["CartId"].Value.ToString();
        }

        public IEnumerable<CartViewModel> GetUserCartItems(string cartId)
        {
            
            return  from ct in DataContext.Carts join p in DataContext.Products
                           on ct.ProductId equals p.PrpductId
                           where ct.CartId==cartId
                           select new CartViewModel
                           {
                               price = p.Price,
                               productId = ct.ProductId,
                               productImage = p.ProductImage,
                               productName =p.ProductName,
                               quantity =ct.Count
                           };
        }
    }
}