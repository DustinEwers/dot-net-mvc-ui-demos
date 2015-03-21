using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.Data.Entity;
using Microsoft.Data.Entity.Metadata;
using System.Collections.Generic;
using System.Linq;

namespace UIDemos.Models
{
	public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
	{
		private static bool _created = false;

		public DbSet<Product> Products { get; set; }
		public DbSet<ShoppingCartItem> CartItems { get; set; }
		
		public ApplicationDbContext()
		{
			// Create the database and schema if it doesn't exist
			// This is a temporary workaround to create database until Entity Framework database migrations 
			// are supported in ASP.NET 5
			if (!_created)
			{
				Database.AsMigrationsEnabled().ApplyMigrations();
				_created = true;
			}

			SeedProducts();
        }

		protected override void OnConfiguring(DbContextOptions options)
		{
			options.UseSqlServer();
		}

		protected override void OnModelCreating(ModelBuilder builder)
		{
			base.OnModelCreating(builder);
			// Customize the ASP.NET Identity model and override the defaults if needed.
			// For example, you can rename the ASP.NET Identity table names and more.
			// Add your customizations after calling base.OnModelCreating(builder);
			
		}

		private void SeedProducts() {
			var products = new List<Product> {
				new Product { Type= ProductType.Beer, Name = "Spotted Cow (6 pack)", Price=7.50m},
				new Product { Type= ProductType.Beer, Name = "Capital Amber (6 pack)", Price=7.00m},
				new Product { Type= ProductType.Food, Name = "Door County Cherries (1lb)", Price=6.25m},
				new Product { Type= ProductType.Food, Name = "Cheese Sampler Pack", Price=23.00m},
				new Product { Type= ProductType.Gear, Name = "Cheese Head Hat", Price=35.00m},
			};

			foreach (var product in products) {
				if (!Products.Any(x => x.Name == product.Name)) {
					Products.Add(product);
				}
			}

			this.SaveChanges();
		}		
	}
}