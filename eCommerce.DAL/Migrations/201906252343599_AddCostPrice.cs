namespace eCommerce.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddCostPrice : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Products", "costPrice", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AlterColumn("dbo.Products", "imageUrl", c => c.String(maxLength: 255));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Products", "imageUrl", c => c.String());
            DropColumn("dbo.Products", "costPrice");
        }
    }
}
