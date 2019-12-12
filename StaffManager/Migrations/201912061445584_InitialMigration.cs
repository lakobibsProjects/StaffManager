namespace StaffManager.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialMigration : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Employees",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(unicode: false),
                        EmploymentDate = c.DateTime(nullable: false, precision: 0),
                        GeneralRate = c.Double(nullable: false),
                        CanBeChief = c.Boolean(nullable: false),
                        Position_ID = c.Int(),
                        Employee_Id = c.Int(),
                        Wage_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Positions", t => t.Position_ID)
                .ForeignKey("dbo.Employees", t => t.Employee_Id)
                .ForeignKey("dbo.Wages", t => t.Wage_Id)
                //.Index(t => t.Position_ID)
                //.Index(t => t.Employee_Id)
                //.Index(t => t.Wage_Id)
                ;
            
            CreateTable(
                "dbo.Positions",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Name = c.String(unicode: false),
                        Discription = c.String(unicode: false),
                        Duties = c.String(unicode: false),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.Wages",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        RateIncrement = c.Double(nullable: false),
                        RateLimit = c.Double(nullable: false),
                        SubordinateBonus = c.Double(nullable: false),
                        HaveSubordinateBonus = c.Boolean(nullable: false),
                        IsSubordinateBonusAllLevels = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            Sql("CREATE index `IX_Position_ID` on `Employees` (`Position_ID` DESC)");
            Sql("CREATE index `IX_Employee_Id` on `Employees` (`Employee_Id` DESC)");
            Sql("CREATE index `IX_Wage_Id` on `Employees` (`Wage_Id` DESC)");

        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Employees", "Wage_Id", "dbo.Wages");
            DropForeignKey("dbo.Employees", "Employee_Id", "dbo.Employees");
            DropForeignKey("dbo.Employees", "Position_ID", "dbo.Positions");
            DropIndex("dbo.Employees", new[] { "Wage_Id" });
            DropIndex("dbo.Employees", new[] { "Employee_Id" });
            DropIndex("dbo.Employees", new[] { "Position_ID" });
            DropTable("dbo.Wages");
            DropTable("dbo.Positions");
            DropTable("dbo.Employees");
        }
    }
}
