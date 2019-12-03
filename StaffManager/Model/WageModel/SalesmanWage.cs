using StaffManager.Model.DBService;
using StaffManager.Model.EmployeeModel;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StaffManager.Model.WageModel
{

    /// <summary>
    /// Calculation of wage employee with all-levels subordinates
    /// </summary>
    public class SalesmanWage : AbstractWage       //todo: rename
    {
        private double subordinatesRateIncrement;

        public SalesmanWage(IEmployee employee) : base(employee)
        {
            RateIncrement = 0.01;
            RateLimit = 0.35;
            subordinatesRateIncrement = 0.003;
        }

        public SalesmanWage(IEmployee employee, double rateIncrement, double rateLimit, double subordinatesRateIncrement) : base(employee)
        {
            RateIncrement = rateIncrement;
            RateLimit = rateLimit;
            this.subordinatesRateIncrement = subordinatesRateIncrement;
        }

        public override double CalculateWage(IEmployee employee, DateTime beginDate, DateTime endDate)
        {
            double result = 0;
            result += CalculateWage(employee.GeneralRate, RateLimit, RateIncrement, beginDate, endDate);
            if (employee.CanBeChief)
                result += SubordinatesBonus(employee);

            return result;
        }
        
        public override double CalculateWage(double generalRate, double rateLimit, double rateIncriment, DateTime beginDate, DateTime endDate)
        {
            double result = generalRate;
            if (endDate > beginDate)
            {
                int yearsOfWork = (DateTime.Now - beginDate).Days / 365;      //todo: correct to leap year
                result = RateIncrement * yearsOfWork > RateLimit ? result * (1 + RateLimit) : result * (1 + RateIncrement * yearsOfWork);
                //result += SubordinatesBonus(employee as Employee);
                //не учитывает подчиненных

                return result;
            }
            else
            {
                throw new ArgumentException("endDate must been hieghest thas beginDate");
            }
        }

        //todo: correct calculate subordinatebonus
        private double SubordinatesBonus(IEmployee beneficiar)
        {       // todo: push dbconnector to signature
            double bonus = 0;
            ObservableCollection<Employee> sub = new ObservableCollectionService().GetSubordinates((beneficiar as Employee));

            foreach (var s in sub)
            {
                if (s.CanBeChief)
                {
                    bonus += SubordinatesBonus(s);
                }
                bonus += s.Wage.CalculateWage(s) * subordinatesRateIncrement;
            }
            
            return bonus;
        }
    }
}
