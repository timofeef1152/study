namespace timofeev.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class mig2 : DbMigration
    {
        public override void Up()
        {
            DropIndex("dbo.Orders", new[] { "Client_Id" });
            DropIndex("dbo.Orders", new[] { "Employee_Id" });
            DropIndex("dbo.Orders", new[] { "OrderTheme_Id" });
            DropIndex("dbo.OrderDetails", new[] { "Confectionery_Id" });
            DropIndex("dbo.OrderDetails", new[] { "Order_Id" });
            DropIndex("dbo.Confectioneries", new[] { "ConfectioneryCategory_Id" });
            DropColumn("dbo.Orders", "ClientId");
            DropColumn("dbo.Orders", "EmployeeId");
            DropColumn("dbo.Orders", "OrderThemeId");
            DropColumn("dbo.OrderDetails", "OrderId");
            DropColumn("dbo.OrderDetails", "ConfectioneryId");
            DropColumn("dbo.Confectioneries", "ConfectioneryCategoryId");
            RenameColumn(table: "dbo.Orders", name: "Client_Id", newName: "ClientId");
            RenameColumn(table: "dbo.Orders", name: "Employee_Id", newName: "EmployeeId");
            RenameColumn(table: "dbo.OrderDetails", name: "Order_Id", newName: "OrderId");
            RenameColumn(table: "dbo.Orders", name: "OrderTheme_Id", newName: "OrderThemeId");
            RenameColumn(table: "dbo.OrderDetails", name: "Confectionery_Id", newName: "ConfectioneryId");
            RenameColumn(table: "dbo.Confectioneries", name: "ConfectioneryCategory_Id", newName: "ConfectioneryCategoryId");
            AlterColumn("dbo.Orders", "ClientId", c => c.String(maxLength: 128));
            AlterColumn("dbo.Orders", "EmployeeId", c => c.String(maxLength: 128));
            AlterColumn("dbo.Orders", "OrderThemeId", c => c.String(maxLength: 128));
            AlterColumn("dbo.OrderDetails", "ConfectioneryId", c => c.String(maxLength: 128));
            AlterColumn("dbo.OrderDetails", "OrderId", c => c.String(maxLength: 128));
            AlterColumn("dbo.Confectioneries", "ConfectioneryCategoryId", c => c.String(maxLength: 128));
            CreateIndex("dbo.Orders", "ClientId");
            CreateIndex("dbo.Orders", "EmployeeId");
            CreateIndex("dbo.Orders", "OrderThemeId");
            CreateIndex("dbo.OrderDetails", "ConfectioneryId");
            CreateIndex("dbo.OrderDetails", "OrderId");
            CreateIndex("dbo.Confectioneries", "ConfectioneryCategoryId");
        }
        
        public override void Down()
        {
            DropIndex("dbo.Confectioneries", new[] { "ConfectioneryCategoryId" });
            DropIndex("dbo.OrderDetails", new[] { "OrderId" });
            DropIndex("dbo.OrderDetails", new[] { "ConfectioneryId" });
            DropIndex("dbo.Orders", new[] { "OrderThemeId" });
            DropIndex("dbo.Orders", new[] { "EmployeeId" });
            DropIndex("dbo.Orders", new[] { "ClientId" });
            AlterColumn("dbo.Confectioneries", "ConfectioneryCategoryId", c => c.Int(nullable: false));
            AlterColumn("dbo.OrderDetails", "OrderId", c => c.Int(nullable: false));
            AlterColumn("dbo.OrderDetails", "ConfectioneryId", c => c.Int(nullable: false));
            AlterColumn("dbo.Orders", "OrderThemeId", c => c.Int(nullable: false));
            AlterColumn("dbo.Orders", "EmployeeId", c => c.Int(nullable: false));
            AlterColumn("dbo.Orders", "ClientId", c => c.Int(nullable: false));
            RenameColumn(table: "dbo.Confectioneries", name: "ConfectioneryCategoryId", newName: "ConfectioneryCategory_Id");
            RenameColumn(table: "dbo.OrderDetails", name: "ConfectioneryId", newName: "Confectionery_Id");
            RenameColumn(table: "dbo.Orders", name: "OrderThemeId", newName: "OrderTheme_Id");
            RenameColumn(table: "dbo.OrderDetails", name: "OrderId", newName: "Order_Id");
            RenameColumn(table: "dbo.Orders", name: "EmployeeId", newName: "Employee_Id");
            RenameColumn(table: "dbo.Orders", name: "ClientId", newName: "Client_Id");
            AddColumn("dbo.Confectioneries", "ConfectioneryCategoryId", c => c.Int(nullable: false));
            AddColumn("dbo.OrderDetails", "ConfectioneryId", c => c.Int(nullable: false));
            AddColumn("dbo.OrderDetails", "OrderId", c => c.Int(nullable: false));
            AddColumn("dbo.Orders", "OrderThemeId", c => c.Int(nullable: false));
            AddColumn("dbo.Orders", "EmployeeId", c => c.Int(nullable: false));
            AddColumn("dbo.Orders", "ClientId", c => c.Int(nullable: false));
            CreateIndex("dbo.Confectioneries", "ConfectioneryCategory_Id");
            CreateIndex("dbo.OrderDetails", "Order_Id");
            CreateIndex("dbo.OrderDetails", "Confectionery_Id");
            CreateIndex("dbo.Orders", "OrderTheme_Id");
            CreateIndex("dbo.Orders", "Employee_Id");
            CreateIndex("dbo.Orders", "Client_Id");
        }
    }
}
