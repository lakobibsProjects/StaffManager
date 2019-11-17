using StaffManager.Model.EmployeeModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StaffManager.Model.WageModel
{
    public class ManagerWage : AbstractWage      //todo: rename
    {
        private double subordinatesRateIncrement;

        public ManagerWage(IEmployee employee) : base(employee)
        {
            RateIncrement = 0.05;
            RateLimit = 0.4;
            subordinatesRateIncrement = 0.005;
        }

        public ManagerWage(IEmployee employee, double rateIncrement, double rateLimit, double subordinatesRateIncrement) : base(employee)
        {
            RateIncrement = rateIncrement;
            RateLimit = rateLimit;
            this.subordinatesRateIncrement = subordinatesRateIncrement;
        }


        public override double CalculateWage(IEmployee employee, DateTime beginDate, DateTime endDate)
        {
            if (endDate > beginDate)
            {
                var result = CalculateWage(employee.GeneralRate, RateLimit, RateIncrement, beginDate, endDate);
                // todo: push dbconnector to signature
                /*foreach (var s in employee.GetSubourdinates(new InternalDBConnector()))
                {
                    result += s.getWage() * subordinatesRateIncrement;     //todo: NRE
                }*/
                return result;
            }
            else
            {
                throw new ArgumentException("endDate must been hieghest thas beginDate");
            }

        }


        public override double CalculateWage(double generalRate, double rateLimit, double rateIncriment, DateTime beginDate, DateTime endDate)
        {
            if (endDate > beginDate)
            {
                double result = generalRate;
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
