using PaystackSampleWebApp.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PaystackSampleWebApp.Controllers
{
    
    public class ShoppingCartController : Controller
    {
        ICart cartRepo;
        public ShoppingCartController(ICart _cartRepo)
        {
            cartRepo = _cartRepo;
        }

        [Route("order/cart")]
        public ActionResult Index()
        {
            string cartId = this.cartRepo.GetCartId(this.HttpContext);
            var cartItems = cartRepo.GetUserCartItems(cartId);
            return View(cartItems);
        }

        [Route("order/checkout")]
        public ActionResult Checkout()
        {
            return View();
        }
    }
}