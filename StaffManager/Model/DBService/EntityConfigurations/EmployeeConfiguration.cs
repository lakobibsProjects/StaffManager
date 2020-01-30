using StaffManager.Model.EmployeeModel;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StaffManager.Model.DBService.EntityConfigurations
{
    public class EmployeeConfiguration : EntityTypeConfiguration<Employee>
    {
        public EmployeeConfiguration()
        {
            //HasOptional<Employee>(c => c.Chief).WithMany(s => s.Subordinates).HasForeignKey(e => e.Id).WillCascadeOnDelete(false);
            HasMany<Employee>(e => e.Subordinates).WithOptional(a => a.Chief).HasForeignKey(e => e.ChiefId).WillCascadeOnDelete(false);
            Property(e => e.Name).IsUnicode(true);
            
        }

    }
}
