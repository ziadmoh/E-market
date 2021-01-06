namespace InternetApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class intial1 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Carts", "product_id", "dbo.Products");
            DropIndex("dbo.Carts", new[] { "product_id" });
            DropPrimaryKey("dbo.Carts");
            AlterColumn("dbo.Carts", "product_id", c => c.Int(nullable: false));
            AddPrimaryKey("dbo.Carts", new[] { "product_id", "added_at" });
            CreateIndex("dbo.Carts", "product_id");
            AddForeignKey("dbo.Carts", "product_id", "dbo.Products", "id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Carts", "product_id", "dbo.Products");
            DropIndex("dbo.Carts", new[] { "product_id" });
            DropPrimaryKey("dbo.Carts");
            AlterColumn("dbo.Carts", "product_id", c => c.Int());
            AddPrimaryKey("dbo.Carts", "added_at");
            CreateIndex("dbo.Carts", "product_id");
            AddForeignKey("dbo.Carts", "product_id", "dbo.Products", "id");
        }
    }
}
