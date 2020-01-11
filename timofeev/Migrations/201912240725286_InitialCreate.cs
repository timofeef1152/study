namespace timofeev.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Clients",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Firstname = c.String(),
                        Name = c.String(),
                        Secondname = c.String(),
                        PhoneNumber = c.String(),
                        DeliveryAddress = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Orders",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        ClientId = c.Int(nullable: false),
                        EmployeeId = c.Int(nullable: false),
                        OrderThemeId = c.Int(nullable: false),
                        Client_Id = c.String(maxLength: 128),
                        Employee_Id = c.String(maxLength: 128),
                        OrderTheme_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Clients", t => t.Client_Id)
                .ForeignKey("dbo.Employees", t => t.Employee_Id)
                .ForeignKey("dbo.OrderThemes", t => t.OrderTheme_Id)
                .Index(t => t.Client_Id)
                .Index(t => t.Employee_Id)
                .Index(t => t.OrderTheme_Id);
            
            CreateTable(
                "dbo.Employees",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        PersonId = c.Int(nullable: false),
                        PositionId = c.Int(nullable: false),
                        RatingId = c.Int(nullable: false),
                        Person_Id = c.String(maxLength: 128),
                        Position_Id = c.String(maxLength: 128),
                        Rating_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.People", t => t.Person_Id)
                .ForeignKey("dbo.Positions", t => t.Position_Id)
                .ForeignKey("dbo.Ratings", t => t.Rating_Id)
                .Index(t => t.Person_Id)
                .Index(t => t.Position_Id)
                .Index(t => t.Rating_Id);
            
            CreateTable(
                "dbo.People",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Firstname = c.String(),
                        Name = c.String(),
                        Secondname = c.String(),
                        Address = c.String(),
                        PhoneNumber = c.String(),
                        Email = c.String(),
                        PassportInfo = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Positions",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        PositionName = c.String(),
                        Salary = c.Single(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Ratings",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        RatingLevel = c.Int(nullable: false),
                        BonusPercent = c.Single(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.OrderDetails",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Quantity = c.Int(nullable: false),
                        TotalAmount = c.Decimal(nullable: false, precision: 18, scale: 2),
                        ConfectioneryId = c.Int(nullable: false),
                        OrderId = c.Int(nullable: false),
                        Confectionery_Id = c.String(maxLength: 128),
                        Order_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Confectioneries", t => t.Confectionery_Id)
                .ForeignKey("dbo.Orders", t => t.Order_Id)
                .Index(t => t.Confectionery_Id)
                .Index(t => t.Order_Id);
            
            CreateTable(
                "dbo.Confectioneries",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Name = c.String(),
                        Composition = c.String(),
                        Price = c.Single(nullable: false),
                        Weight = c.Single(nullable: false),
                        ConfectioneryCategoryId = c.Int(nullable: false),
                        ConfectioneryCategory_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.ConfectioneryCategories", t => t.ConfectioneryCategory_Id)
                .Index(t => t.ConfectioneryCategory_Id);
            
            CreateTable(
                "dbo.ConfectioneryCategories",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        CategoryName = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.OrderThemes",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Description = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Orders", "OrderTheme_Id", "dbo.OrderThemes");
            DropForeignKey("dbo.OrderDetails", "Order_Id", "dbo.Orders");
            DropForeignKey("dbo.OrderDetails", "Confectionery_Id", "dbo.Confectioneries");
            DropForeignKey("dbo.Confectioneries", "ConfectioneryCategory_Id", "dbo.ConfectioneryCategories");
            DropForeignKey("dbo.Employees", "Rating_Id", "dbo.Ratings");
            DropForeignKey("dbo.Employees", "Position_Id", "dbo.Positions");
            DropForeignKey("dbo.Employees", "Person_Id", "dbo.People");
            DropForeignKey("dbo.Orders", "Employee_Id", "dbo.Employees");
            DropForeignKey("dbo.Orders", "Client_Id", "dbo.Clients");
            DropIndex("dbo.Confectioneries", new[] { "ConfectioneryCategory_Id" });
            DropIndex("dbo.OrderDetails", new[] { "Order_Id" });
            DropIndex("dbo.OrderDetails", new[] { "Confectionery_Id" });
            DropIndex("dbo.Employees", new[] { "Rating_Id" });
            DropIndex("dbo.Employees", new[] { "Position_Id" });
            DropIndex("dbo.Employees", new[] { "Person_Id" });
            DropIndex("dbo.Orders", new[] { "OrderTheme_Id" });
            DropIndex("dbo.Orders", new[] { "Employee_Id" });
            DropIndex("dbo.Orders", new[] { "Client_Id" });
            DropTable("dbo.OrderThemes");
            DropTable("dbo.ConfectioneryCategories");
            DropTable("dbo.Confectioneries");
            DropTable("dbo.OrderDetails");
            DropTable("dbo.Ratings");
            DropTable("dbo.Positions");
            DropTable("dbo.People");
            DropTable("dbo.Employees");
            DropTable("dbo.Orders");
            DropTable("dbo.Clients");
        }
    }
}
