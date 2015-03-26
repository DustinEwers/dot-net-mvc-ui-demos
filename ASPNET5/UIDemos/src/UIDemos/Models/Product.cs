
namespace UIDemos.Models
{
	public enum ProductType {
		All,
		Gear,
		Food,
		Beer
	}
	
	public class Product
	{
		public int Id { get; set; }
		public ProductType Type { get; set; }
		public string Name { get; set; }
		public string Description { get; set; }
		public decimal Price { get; set; }
    }
}