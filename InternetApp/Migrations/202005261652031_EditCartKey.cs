namespace InternetApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class EditCartKey : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Carts", "product_id", "dbo.Products");
            DropPrimaryKey("dbo.Carts");
            AddPrimaryKey("dbo.Carts", "product_id");
            CreateIndex("dbo.Products", "name", unique: true);
            AddForeignKey("dbo.Carts", "product_id", "dbo.Products", "id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Carts", "product_id", "dbo.Products");
            DropIndex("dbo.Products", new[] { "name" });
            DropPrimaryKey("dbo.Carts");
            AddPrimaryKey("dbo.Carts", new[] { "product_id", "added_at" });
            AddForeignKey("dbo.Carts", "product_id", "dbo.Products", "id", cascadeDelete: true);
        }
    }
}
