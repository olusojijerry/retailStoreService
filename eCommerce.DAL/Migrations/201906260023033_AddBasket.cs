namespace eCommerce.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddBasket : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.BasketItems",
                c => new
                    {
                        basketItemId = c.Int(nullable: false, identity: true),
                        basketId = c.Int(nullable: false),
                        productId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.basketItemId)
                .ForeignKey("dbo.Products", t => t.productId, cascadeDelete: true)
                .ForeignKey("dbo.Baskets", t => t.basketId, cascadeDelete: true)
                .Index(t => t.basketId)
                .Index(t => t.productId);
            
            CreateTable(
                "dbo.Baskets",
                c => new
                    {
                        basketId = c.Int(nullable: false, identity: true),
                        date = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.basketId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.BasketItems", "basketId", "dbo.Baskets");
            DropForeignKey("dbo.BasketItems", "productId", "dbo.Products");
            DropIndex("dbo.BasketItems", new[] { "productId" });
            DropIndex("dbo.BasketItems", new[] { "basketId" });
            DropTable("dbo.Baskets");
            DropTable("dbo.BasketItems");
        }
    }
}
