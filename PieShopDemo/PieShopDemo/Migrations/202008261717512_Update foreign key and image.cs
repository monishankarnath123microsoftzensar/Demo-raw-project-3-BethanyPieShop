namespace PieShopDemo.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Updateforeignkeyandimage : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.OrderDetails", "PiesId", c => c.Int(nullable: false));
            AddColumn("dbo.OrderDetails", "RegisterUserId", c => c.Int(nullable: false));
            AddColumn("dbo.PieReviews", "PiesId", c => c.Int(nullable: false));
            AddColumn("dbo.Pies", "Image", c => c.String());
            AddColumn("dbo.Pies", "ImageThumb", c => c.String());
            AddColumn("dbo.Pies", "PieCategoryId", c => c.Int(nullable: false));
            CreateIndex("dbo.OrderDetails", "PiesId");
            CreateIndex("dbo.OrderDetails", "RegisterUserId");
            CreateIndex("dbo.Pies", "PieCategoryId");
            CreateIndex("dbo.PieReviews", "PiesId");
            AddForeignKey("dbo.Pies", "PieCategoryId", "dbo.PieCategories", "Id", cascadeDelete: true);
            AddForeignKey("dbo.OrderDetails", "PiesId", "dbo.Pies", "Id", cascadeDelete: true);
            AddForeignKey("dbo.OrderDetails", "RegisterUserId", "dbo.RegisterUsers", "Id", cascadeDelete: true);
            AddForeignKey("dbo.PieReviews", "PiesId", "dbo.Pies", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.PieReviews", "PiesId", "dbo.Pies");
            DropForeignKey("dbo.OrderDetails", "RegisterUserId", "dbo.RegisterUsers");
            DropForeignKey("dbo.OrderDetails", "PiesId", "dbo.Pies");
            DropForeignKey("dbo.Pies", "PieCategoryId", "dbo.PieCategories");
            DropIndex("dbo.PieReviews", new[] { "PiesId" });
            DropIndex("dbo.Pies", new[] { "PieCategoryId" });
            DropIndex("dbo.OrderDetails", new[] { "RegisterUserId" });
            DropIndex("dbo.OrderDetails", new[] { "PiesId" });
            DropColumn("dbo.Pies", "PieCategoryId");
            DropColumn("dbo.Pies", "ImageThumb");
            DropColumn("dbo.Pies", "Image");
            DropColumn("dbo.PieReviews", "PiesId");
            DropColumn("dbo.OrderDetails", "RegisterUserId");
            DropColumn("dbo.OrderDetails", "PiesId");
        }
    }
}
