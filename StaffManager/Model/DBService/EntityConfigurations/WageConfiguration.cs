using StaffManager.Model.WageModel;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StaffManager.Model.DBService.EntityConfigurations
{
    public class WageConfiguration : EntityTypeConfiguration<Wage>
    {
        public WageConfiguration()
        {

        }
    }
}
