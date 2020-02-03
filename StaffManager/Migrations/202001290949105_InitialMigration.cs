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
                    ChiefId = c.Int(),
                    CanBeChief = c.Boolean(nullable: false),
                    Position_Id = c.Int(),
                    Salary_Id = c.Int(),
                })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Positions", t => t.Position_Id)
                .ForeignKey("dbo.Salaries", t => t.Salary_Id)
                .ForeignKey("dbo.Employees", t => t.ChiefId);

            Sql("CREATE index `IX_ChiefId` on `Employees` (`ChiefId` DESC)");
            Sql("CREATE index `IX_Position_Id` on `Employees` (`Position_Id` DESC)");
            Sql("CREATE index `IX_Salary_Id` on `Employees` (`Salary_Id` DESC)");

            CreateTable(
                "dbo.Positions",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, unicode: false),
                        Discription = c.String(unicode: false),
                        Duties = c.String(unicode: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Salaries",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, unicode: false),
                        RateIncrement = c.Double(nullable: false),
                        RateLimit = c.Double(nullable: false),
                        SubordinateBonus = c.Double(),
                        HaveSubordinateBonus = c.Boolean(nullable: false),
                        IsSubordinateBonusAllLevels = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Employees", "ChiefId", "dbo.Employees");
            DropForeignKey("dbo.Employees", "Salary_Id", "dbo.Salaries");
            DropForeignKey("dbo.Employees", "Position_Id", "dbo.Positions");
            DropIndex("dbo.Employees", new[] { "Salary_Id" });
            DropIndex("dbo.Employees", new[] { "Position_Id" });
            DropIndex("dbo.Employees", new[] { "ChiefId" });
            DropTable("dbo.Salaries");
            DropTable("dbo.Positions");
            DropTable("dbo.Employees");
        }
    }
}
