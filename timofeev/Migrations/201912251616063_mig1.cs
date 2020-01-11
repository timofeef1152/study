namespace timofeev.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class mig1 : DbMigration
    {
        public override void Up()
        {
            DropIndex("dbo.Employees", new[] { "Person_Id" });
            DropIndex("dbo.Employees", new[] { "Position_Id" });
            DropIndex("dbo.Employees", new[] { "Rating_Id" });
            DropColumn("dbo.Employees", "PersonId");
            DropColumn("dbo.Employees", "PositionId");
            DropColumn("dbo.Employees", "RatingId");
            RenameColumn(table: "dbo.Employees", name: "Person_Id", newName: "PersonId");
            RenameColumn(table: "dbo.Employees", name: "Position_Id", newName: "PositionId");
            RenameColumn(table: "dbo.Employees", name: "Rating_Id", newName: "RatingId");
            AlterColumn("dbo.Employees", "PersonId", c => c.String(maxLength: 128));
            AlterColumn("dbo.Employees", "PositionId", c => c.String(maxLength: 128));
            AlterColumn("dbo.Employees", "RatingId", c => c.String(maxLength: 128));
            CreateIndex("dbo.Employees", "PersonId");
            CreateIndex("dbo.Employees", "PositionId");
            CreateIndex("dbo.Employees", "RatingId");
        }
        
        public override void Down()
        {
            DropIndex("dbo.Employees", new[] { "RatingId" });
            DropIndex("dbo.Employees", new[] { "PositionId" });
            DropIndex("dbo.Employees", new[] { "PersonId" });
            AlterColumn("dbo.Employees", "RatingId", c => c.Int(nullable: false));
            AlterColumn("dbo.Employees", "PositionId", c => c.Int(nullable: false));
            AlterColumn("dbo.Employees", "PersonId", c => c.Int(nullable: false));
            RenameColumn(table: "dbo.Employees", name: "RatingId", newName: "Rating_Id");
            RenameColumn(table: "dbo.Employees", name: "PositionId", newName: "Position_Id");
            RenameColumn(table: "dbo.Employees", name: "PersonId", newName: "Person_Id");
            AddColumn("dbo.Employees", "RatingId", c => c.Int(nullable: false));
            AddColumn("dbo.Employees", "PositionId", c => c.Int(nullable: false));
            AddColumn("dbo.Employees", "PersonId", c => c.Int(nullable: false));
            CreateIndex("dbo.Employees", "Rating_Id");
            CreateIndex("dbo.Employees", "Position_Id");
            CreateIndex("dbo.Employees", "Person_Id");
        }
    }
}
