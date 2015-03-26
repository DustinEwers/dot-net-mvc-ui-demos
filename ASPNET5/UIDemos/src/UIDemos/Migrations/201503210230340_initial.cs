using Microsoft.Data.Entity.Relational.Migrations;
using Microsoft.Data.Entity.Relational.Migrations.Builders;
using Microsoft.Data.Entity.Relational.Migrations.MigrationsModel;
using System;

namespace UIDemos.Migrations
{
    public partial class initial : Migration
    {
        public override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable("Product",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Description = c.String(),
                        Name = c.String(),
                        Price = c.Decimal(nullable: false),
                        Type = c.Int(nullable: false)
                    })
                .PrimaryKey("PK_Product", t => t.Id);
            
            migrationBuilder.CreateTable("ShoppingCartItem",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Quantity = c.Int(nullable: false),
                        ProductId = c.Int()
                    })
                .PrimaryKey("PK_ShoppingCartItem", t => t.Id);
            
            migrationBuilder.AddForeignKey(
                "ShoppingCartItem",
                "FK_ShoppingCartItem_Product_ProductId",
                new[] { "ProductId" },
                "Product",
                new[] { "Id" },
                cascadeDelete: false);
        }
        
        public override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey("ShoppingCartItem", "FK_ShoppingCartItem_Product_ProductId");
            
            migrationBuilder.DropTable("Product");
            
            migrationBuilder.DropTable("ShoppingCartItem");
        }
    }
}