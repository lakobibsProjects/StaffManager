using StaffManager.Model.EmployeeModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StaffManager.Model.WageModel
{
    /// <summary>
    /// General calculation of wage
    /// </summary>
    public class EmployeeSalary : AbstractSalary      //todo: rename 
    {
        public EmployeeSalary(IEmployee employee) : base(employee)
        {
            RateIncrement = 0.03;
            RateLimit = 0.3;
        }

        public EmployeeSalary(IEmployee employee, double rateIncrement, double rateLimit) : base(employee)
        {
            RateIncrement = rateIncrement;
            RateLimit = rateLimit;
        }

        public override double CalculateSalary(IEmployee employee, DateTime beginDate, DateTime endDate) => CalculateSalary(employee.GeneralRate, RateLimit, RateIncrement, beginDate, endDate);


        public override double CalculateSalary(double generalRate, double rateLimit, double rateIncriment, DateTime beginDate, DateTime endDate)
        {
            double result = generalRate;
            if (endDate > beginDate)
            {
                int yearsOfWork = (endDate - beginDate).Days / 365;      //todo: correct to leap year
                result = RateIncrement * yearsOfWork > RateLimit ? result * (1 + RateLimit) : result * (1 + RateIncrement * yearsOfWork);

                return result;
            }
            else
            {
                throw new ArgumentException("endDate must been hieghest thas beginDate");
            }
        }
    }
}
