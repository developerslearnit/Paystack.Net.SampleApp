using PaystackSampleWebApp.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PaystackSampleWebApp.Controllers
{
    public class HomeController : Controller
    {
        IProducts repo;
        ICart cartRepo;
        public HomeController(IProducts _repo, ICart _cartRepo)
        {
            this.repo = _repo;
            this.cartRepo = _cartRepo;
        }

        // GET: Home
        public ActionResult Index()
        {
            return View();
        }


        public ActionResult PorductsPartial()
        {
            var products = repo.GetAllProducts();
            return View(products);
        }
    }
}