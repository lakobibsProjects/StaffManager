using StaffManager.Model.EmployeeModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StaffManager.Model.WageModel
{
    public class EmployeeWage : AbstractWage      //todo: rename
    {
        public EmployeeWage(IEmployee employee) : base(employee)
        {
            RateIncrement = 0.03;
            RateLimit = 0.3;
        }

        public EmployeeWage(IEmployee employee, double rateIncrement, double rateLimit) : base(employee)
        {
            RateIncrement = rateIncrement;
            RateLimit = rateLimit;
        }

        public override double CalculateWage(IEmployee employee, DateTime beginDate, DateTime endDate) => CalculateWage(employee.GeneralRate, RateLimit, RateIncrement, beginDate, endDate);


        public override double CalculateWage(double generalRate, double rateLimit, double rateIncriment, DateTime beginDate, DateTime endDate)
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
