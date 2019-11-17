using StaffManager.Model.EmployeeModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StaffManager.Model.WageModel
{
    public interface IWage
    {
        double RateIncrement { get; }
        double RateLimit { get; }
        double CalculateWage(IEmployee employee);
        double CalculateWage(IEmployee employee, DateTime beginDate, DateTime endDate);
    }
}
