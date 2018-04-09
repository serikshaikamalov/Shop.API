namespace Shop.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedImageField : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Products", "ImageID", c => c.Int());
            CreateIndex("dbo.Products", "ImageID");
            AddForeignKey("dbo.Products", "ImageID", "dbo.Images", "ImageID");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Products", "ImageID", "dbo.Images");
            DropIndex("dbo.Products", new[] { "ImageID" });
            DropColumn("dbo.Products", "ImageID");
        }
    }
}
