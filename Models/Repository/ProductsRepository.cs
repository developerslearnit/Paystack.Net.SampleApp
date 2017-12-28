using PaystackSampleWebApp.Models.DataModel;
using PaystackSampleWebApp.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PaystackSampleWebApp.Models.Repository
{
    public class ProductsRepository : BaseRepository<ShoppingCartEntities>, IProducts
    {
        public bool AddToCart(Cart cart)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Product> GetAllProducts()
        {
            return DataContext.Products;
        }
    }
}