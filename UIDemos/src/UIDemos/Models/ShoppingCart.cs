using System;
using System.Collections.Generic;

namespace UIDemos.Models
{
	public class ShoppingCartItem
	{
		public Product Product { get; set; }
		public int Quantity { get; set; }
	}

	public class ShoppingCart
	{
		public List<ShoppingCartItem> Items { get; set; }

		public decimal SubTotal { get; set; }
    }
}