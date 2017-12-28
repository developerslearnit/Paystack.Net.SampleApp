using PaystackSampleWebApp.Models.DataModel;
using PaystackSampleWebApp.Models.Interfaces;
using PaystackSampleWebApp.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Paystack.Net.SDK.Transactions;
using System.Threading.Tasks;
using System.Configuration;

namespace PaystackSampleWebApp.Controllers
{
    public class AppLogicController : Controller
    {
        IProducts repo;
        ICart cartRepo;
        public AppLogicController(IProducts _repo, ICart _cartRepo)
        {
            this.repo = _repo;
            this.cartRepo = _cartRepo;
        }

        public async Task<JsonResult> InitializePayment(PaystackCustomerModel model)
        {
            string secretKey = ConfigurationManager.AppSettings["PaystackSecret"];
            var paystackTransactionAPI = new PaystackTransaction(secretKey);
            var response = await paystackTransactionAPI.InitializeTransaction(model.email, model.amount, model.firstName, model.lastName, "http://localhost:17869/order/callback");
            //Note that callback url is optional
            if (response.status == true)
            {
                return Json(new {error=false,result= response }, JsonRequestBehavior.AllowGet);
            }
            return Json(new { error = true, result = response }, JsonRequestBehavior.AllowGet);

        }

        public JsonResult CartItemCount()
        {
            string cartId = this.cartRepo.GetCartId(this.HttpContext);

            var itemCount = cartRepo.GetCartItems().Count(x => x.CartId == cartId);
            return Json(new { error = false,itemCount = $"{itemCount}- item(s) " }, JsonRequestBehavior.AllowGet);
        }


        public JsonResult AddToCart(Cart cart)
        {
            
            var exceptionMessage = string.Empty;
            try
            {
                string cartId = string.Empty;
                cartId = this.cartRepo.GetCartId(this.HttpContext);

                if (User.Identity.IsAuthenticated)
                {
                    cartId = User.Identity.Name;
                }
                cartId = this.cartRepo.GetCartId(this.HttpContext);
                cart.Count = 1;
                cart.DateCreated = DateTime.Now;
                cart.CartId = cartId;

                if (cartRepo.AddToCart(cart))
                {
                    return Json(new { error = false }, JsonRequestBehavior.AllowGet);
                }

                return Json(new { error = true, message = "Error adding item to cart" }, JsonRequestBehavior.AllowGet);

            }
            catch (Exception ex)
            {
                exceptionMessage = ex.Message;
            }

            return Json(new { error = true, message = exceptionMessage }, JsonRequestBehavior.AllowGet);
        }
    }
}