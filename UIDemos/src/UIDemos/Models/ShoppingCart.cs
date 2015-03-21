using System.Collections.Generic;
using System.Linq;

namespace UIDemos.Models
{
	public class ShoppingCartItem
	{
		public int Id { get; set; }
		public Product Product { get; set; }
		public int Quantity { get; set; }
	}

	public class ShoppingCart
	{
		public List<ShoppingCartItem> Items { get; set; }

		public decimal SubTotal { get {
				if (Items == null || Items.Count < 1) {
					return 0;
				}

				return Items.Sum(si => si.Product.Price);
			}
		}
    }
}