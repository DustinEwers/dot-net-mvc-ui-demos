using System.ComponentModel.DataAnnotations;

namespace UIDemos.Models
{
    public class CatalogSearchViewModel
    {	
		public ProductType Type { get; set; }
		public string Name { get; set; }

		public decimal StartPrice { get; set; }

		public decimal EndPrice { get; set; }
	}
}