using StaffManager.Model.EmployeeModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StaffManager.Model.WageModel
{
    public interface ISalary : IEntity
    {
        double RateIncrement { get; }
        double RateLimit { get; }
        double SubordinateBonus { get; }
        bool HaveSubordinateBonus { get; }
        bool IsSubordinateBonusAllLevels { get; }
        double CalculateSalary(IEmployee employee);
        double CalculateSalary(IEmployee employee, DateTime beginDate, DateTime endDate);
    }
}
