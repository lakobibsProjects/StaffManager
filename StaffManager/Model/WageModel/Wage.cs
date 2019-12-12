using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StaffManager.Model.DBService;
using StaffManager.Model.EmployeeModel;

namespace StaffManager.Model.WageModel
{
    public class Wage : AbstractWage
    {
        public Wage(IEmployee employee) : base(employee)
        {
        }

        public Wage()
        {

        }

        public Wage(IEmployee employee, double rateIncrement, double rateLimit, bool haveSubordinateBonus = false, bool isSubordinateBonusAllLevels = false, double subrodinateBonus = 0) : base(employee)
        {
            RateIncrement = rateIncrement;
            RateLimit = rateLimit;
            SubordinateBonus = subrodinateBonus;
            HaveSubordinateBonus = haveSubordinateBonus;
            IsSubordinateBonusAllLevels = isSubordinateBonusAllLevels;
        }

        //не учитывает подчиненных
        public override double CalculateWage(double generalRate, double rateLimit, double rateIncriment, DateTime beginDate, DateTime endDate)
        {
            double result = generalRate;
            if (endDate > beginDate)
            {
                int yearsOfWork = (DateTime.Now - beginDate).Days / 365;      //todo: correct to leap year
                result = RateIncrement * yearsOfWork > RateLimit ? result * (1 + RateLimit) : result * (1 + RateIncrement * yearsOfWork);
                //result += SubordinatesBonus(employee as Employee);

                return result;
            }
            else
            {
                throw new ArgumentException("endDate must been hieghest thas beginDate");
            }
        }

        public override double CalculateWage(IEmployee employee, DateTime beginDate, DateTime endDate)
        {
            double result = employee.GeneralRate;
            if (endDate > beginDate)
            {
                int yearsOfWork = (endDate - beginDate).Days / 365;      //todo: correct to leap year
                result = RateIncrement * yearsOfWork > RateLimit ? result * (1 + RateLimit) : result * (1 + RateIncrement * yearsOfWork);

                if (HaveSubordinateBonus)
                    result += SubordinatesBonus(employee as Employee);

                return result;
            }
            else
            {
                throw new ArgumentException("endDate must been hieghest thas beginDate");
            }
        }

        private double SubordinatesBonus(IEmployee beneficiar)
        {
            double bonus = 0;
            ObservableCollection<Employee> subordinates = beneficiar.Subordinates;

            foreach (var s in subordinates)
            {
                if (IsSubordinateBonusAllLevels && s.CanBeChief)
                    bonus += SubordinatesBonus(s);

                bonus += s.Wage.CalculateWage(s) * SubordinateBonus;
            }

            return bonus;
        }
    }
}
