namespace eCommerce.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Customers",
                c => new
                    {
                        customerId = c.Int(nullable: false, identity: true),
                        customerName = c.String(),
                        address1 = c.String(),
                        town = c.String(),
                        postCode = c.String(),
                    })
                .PrimaryKey(t => t.customerId);
            
            CreateTable(
                "dbo.OrderItems",
                c => new
                    {
                        orderItemId = c.Int(nullable: false, identity: true),
                        productId = c.Int(nullable: false),
                        quantity = c.Int(nullable: false),
                        price = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Order_orderId = c.Int(),
                    })
                .PrimaryKey(t => t.orderItemId)
                .ForeignKey("dbo.Orders", t => t.Order_orderId)
                .Index(t => t.Order_orderId);
            
            CreateTable(
                "dbo.Orders",
                c => new
                    {
                        orderId = c.Int(nullable: false, identity: true),
                        orderDate = c.DateTime(nullable: false),
                        customerId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.orderId);
            
            CreateTable(
                "dbo.Products",
                c => new
                    {
                        productId = c.Int(nullable: false, identity: true),
                        description = c.String(),
                        imageUrl = c.String(),
                        price = c.Decimal(nullable: false, precision: 18, scale: 2),
                    })
                .PrimaryKey(t => t.productId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.OrderItems", "Order_orderId", "dbo.Orders");
            DropIndex("dbo.OrderItems", new[] { "Order_orderId" });
            DropTable("dbo.Products");
            DropTable("dbo.Orders");
            DropTable("dbo.OrderItems");
            DropTable("dbo.Customers");
        }
    }
}
