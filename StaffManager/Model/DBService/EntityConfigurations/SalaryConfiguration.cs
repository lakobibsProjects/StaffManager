using StaffManager.Model.WageModel;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StaffManager.Model.DBService.EntityConfigurations
{
    public class SalaryConfiguration : EntityTypeConfiguration<Salary>
    {
        public SalaryConfiguration()
        {
            Property(s => s.SubordinateBonus).IsOptional();
            Property(s => s.Name).IsRequired().IsUnicode(true);
        }
    }
}
