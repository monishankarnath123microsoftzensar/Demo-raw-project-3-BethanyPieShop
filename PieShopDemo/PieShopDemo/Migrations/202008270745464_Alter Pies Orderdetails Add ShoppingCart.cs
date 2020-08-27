namespace PieShopDemo.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AlterPiesOrderdetailsAddShoppingCart : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.ShoppingCartItems",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        AmountToPay = c.Single(nullable: false),
                        OrderDetailsId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.OrderDetails", t => t.OrderDetailsId, cascadeDelete: true)
                .Index(t => t.OrderDetailsId);
            
            AddColumn("dbo.OrderDetails", "Quantity", c => c.Int(nullable: false));
            AlterColumn("dbo.OrderDetails", "Amount", c => c.Single(nullable: false));
            DropColumn("dbo.OrderDetails", "SubPrice");
            DropColumn("dbo.Pies", "SugerLvl");
            DropColumn("dbo.Pies", "Discount");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Pies", "Discount", c => c.Int(nullable: false));
            AddColumn("dbo.Pies", "SugerLvl", c => c.Int(nullable: false));
            AddColumn("dbo.OrderDetails", "SubPrice", c => c.Single(nullable: false));
            DropForeignKey("dbo.ShoppingCartItems", "OrderDetailsId", "dbo.OrderDetails");
            DropIndex("dbo.ShoppingCartItems", new[] { "OrderDetailsId" });
            AlterColumn("dbo.OrderDetails", "Amount", c => c.Int(nullable: false));
            DropColumn("dbo.OrderDetails", "Quantity");
            DropTable("dbo.ShoppingCartItems");
        }
    }
}
