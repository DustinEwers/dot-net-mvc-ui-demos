using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNet.Mvc;
using vNextUIDemos.Models;

namespace vNextUIDemos.ViewComponents
{
    public class ShoppingCartViewComponent : ViewComponent
    {
        public ShoppingCartViewComponent()
        {
        }

        public IViewComponentResult Invoke()
        {
            var cart = new ShoppingCart()
            {
                Items = new List<ShoppingCartItem>()
            };

            AddProducts(cart);

            // ReSharper disable once Mvc.ViewNotResolved
            return View(cart);
        }
        
        // TODO - Actually hook up the shopping cart with real product adds. 
        private void AddProducts(ShoppingCart cart)
        {
            var products = new List<Product>
            {
                new Product { Name="Test Product", Description = "Test Product Description", Price = 1.25m, Type = ProductType.Gear}
            };

            foreach (var product in products)
            {
                cart.Items.Add(new ShoppingCartItem { Product = product, Quantity = 2 });
            }
        }
    }
}
