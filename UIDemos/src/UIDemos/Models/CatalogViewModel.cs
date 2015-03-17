using System.Collections.Generic;

namespace UIDemos.Models
{
	public class CatalogViewModel
    {
		public CatalogSearchViewModel SearchCriteria { get; set; }

		public List<Product> Products { get; set; }

    }
}