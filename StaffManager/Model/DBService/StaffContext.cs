using StaffManager.Model.EmployeeModel;
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
    public class StaffContext : DbContext
    {
        public StaffContext() :
            base(new SQLiteConnection()
            {
                //упрощение. datasource содержит абсолютный путь. необходимо заменить на относительный
                //проблема не может найти SQLite.interop.dll
                ConnectionString = new SQLiteConnectionStringBuilder() { DataSource = "C:\\Projects\\C#\\StaffManager\\StaffManager\\StaffManager\\StaffManagerDB.db", ForeignKeys = true }.ConnectionString
            }, true)
        {
            Database.SetInitializer<StaffContext>(null);
        }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
            modelBuilder.Entity<Employee>().Ignore(e => e.Subordinates);
            modelBuilder.Entity<Employee>().Ignore(e => e.Wage);

            base.OnModelCreating(modelBuilder);
        }

        public DbSet<Employee> Employees { get; set; }
    }
}
