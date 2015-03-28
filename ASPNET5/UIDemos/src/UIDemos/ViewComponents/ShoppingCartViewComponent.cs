using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNet.Mvc;
using UIDemos.Models;

namespace UIDemos.ViewComponents
{
    public class ShoppingCartViewComponent : ViewComponent
    {
		private readonly ApplicationDbContext _db;

		public ShoppingCartViewComponent(ApplicationDbContext context) {
			_db = context;
		}

		public IViewComponentResult Invoke() {
			var cart = new ShoppingCart()
			{
				Items = new List<ShoppingCartItem>()
			};

			AddProducts(cart);

			// ReSharper disable once Mvc.ViewNotResolved
			return View(cart);
		}
		
		// TODO - Actually hook up the shopping cart with real product adds. 
		private void AddProducts(ShoppingCart cart) {
			var products = _db.Products.Where(x => x.Type != ProductType.Beer);
			foreach (var product in products)
			{
				cart.Items.Add(new ShoppingCartItem { Product = product, Quantity = 2 });
			}
		}
    }
}