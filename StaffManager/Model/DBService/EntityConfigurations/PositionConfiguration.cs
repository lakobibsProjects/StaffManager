using StaffManager.Model.PositionModel;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StaffManager.Model.DBService.EntityConfigurations
{
    class PositionConfiguration : EntityTypeConfiguration<Position>
    {
        public PositionConfiguration()
        {
            Property(p => p.Discription).IsOptional().IsUnicode(true);
            Property(p => p.Duties).IsOptional().IsUnicode(true);
            Property(p => p.Name).IsRequired().IsUnicode(true);
        }
    }
}
