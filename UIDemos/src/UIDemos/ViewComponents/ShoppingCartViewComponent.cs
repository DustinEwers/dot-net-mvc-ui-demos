using Microsoft.AspNet.Mvc;
using UIDemos.Models;
using System.Collections.Generic;
using System.Linq;

namespace UIDemos.Views.Shared.Components
{
    public class ShoppingCartViewComponent : ViewComponent
    {
		private readonly ApplicationDbContext db;

		public ShoppingCartViewComponent(ApplicationDbContext context) {
			db = context;
		}

		public IViewComponentResult Invoke() {
			var cart = new ShoppingCart()
			{
				Items = new List<ShoppingCartItem>()
			};

			AddProducts(cart);

			return View(cart);
		}
		
		// TODO - Actually hook up the shopping cart with real product adds. 
		private void AddProducts(ShoppingCart cart) {
			var products = db.Products.Where(x => x.Type != ProductType.Beer);
			foreach (var product in products)
			{
				cart.Items.Add(new ShoppingCartItem { Product = product, Quantity = 2 });
			}
		}
    }
}