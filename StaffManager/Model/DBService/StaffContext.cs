using MySql.Data.Entity;
using StaffManager.Model.DBService.EntityConfigurations;
using StaffManager.Model.EmployeeModel;
using StaffManager.Model.PositionModel;
using StaffManager.Model.WageModel;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StaffManager.Model.DBService
{
    //создать таблицы методов рассчета заработной платы и должностей
    [DbConfigurationType(typeof(MySqlEFConfiguration))]
    public class StaffContext : DbContext
    {
        public StaffContext() : base("name=MySqlConnection")
        {
            
        }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new EmployeeConfiguration());
            modelBuilder.Configurations.Add(new PositionConfiguration());
            modelBuilder.Configurations.Add(new WageConfiguration());
           
        } 
        
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Position> Positions { get; set; }
        public DbSet<Wage> WageTypes { get; set; }
    }
}
