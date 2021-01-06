namespace InternetApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class update : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Products", "name", c => c.String(nullable: false, maxLength: 50));
            AlterColumn("dbo.Categories", "name", c => c.String(nullable: false, maxLength: 50));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Categories", "name", c => c.String());
            AlterColumn("dbo.Products", "name", c => c.String(nullable: false));
        }
    }
}
