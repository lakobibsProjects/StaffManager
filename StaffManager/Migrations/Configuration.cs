namespace StaffManager.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<StaffManager.Model.DBService.StaffContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(StaffManager.Model.DBService.StaffContext context)
        {
            context.WageTypes.AddOrUpdate(w => w.Id,
                new Model.WageModel.Wage(null, 0.03, 0.3) { Id = 0 },
                new Model.WageModel.Wage(null, 0.05, 0.4, true, false, 0.005) { Id = 1 },
                new Model.WageModel.Wage(null, 0.01, 0.35, true, true, 0.003) { Id = 2 }
                );
            context.Positions.AddOrUpdate(p => p.ID,
                new Model.PositionModel.Position() { ID = 0, Name = "General employee" },
                new Model.PositionModel.Position() { ID = 1, Name = "Manager" },
                new Model.PositionModel.Position() { ID = 2, Name = "Salesman" }
                );
        }
    }
}
