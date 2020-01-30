using StaffManager.Model.EmployeeModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StaffManager.Model.WageModel
{
    public abstract class AbstractSalary : ISalary
    {
        #region Fields
        private IEmployee employee;
        private double rateIncrement;
        private double rateLimit;
        private double subordinateBonus;
        private bool haveSubordinateBonus;
        private bool isSubordinateBonusAllLevels;
        #endregion

        public int Id { get; set; }
        public string Name { get; set; }
        /// <summary>
        /// Advancement of wage per year in percent
        /// </summary>
        public double RateIncrement
        {
            get { return rateIncrement; }
            protected set
            {
                if (value < 1 || value > 0)
                {
                    rateIncrement = value;
                }
                else
                {
                    throw new ArgumentException("Rate must been between 0 and 1");
                }
            }
        }
        /// <summary>
        /// Limit of advancement of wage folowing work expirience in percent
        /// </summary>
        public double RateLimit
        {
            get { return rateLimit; }
            protected set
            {
                if (value < 1 || value > 0)
                {
                    rateLimit = value;
                }
                else
                {
                    throw new ArgumentException("Limit must been between 0 and 1");
                }
            }
        }

        public double SubordinateBonus
        {
            get { return subordinateBonus; }
            protected set
            {
                if (value < 1 || value > 0)
                {
                    subordinateBonus = value;
                }
                else
                {
                    throw new ArgumentException("Limit must been between 0 and 1");
                }
            }
        }

        public bool HaveSubordinateBonus
        {
            get { return haveSubordinateBonus; }
            protected set
            {
                haveSubordinateBonus = value;
            }
        }

        public bool IsSubordinateBonusAllLevels
        {
            get
            {
                if (haveSubordinateBonus == false)
                    return false;

                return isSubordinateBonusAllLevels;
            }
            protected set
            {
                if (haveSubordinateBonus == false)
                    isSubordinateBonusAllLevels = false;

                isSubordinateBonusAllLevels = value;
            }
        }
        public AbstractSalary(IEmployee employee)
        {
            this.employee = employee;
        }
        public AbstractSalary()
        {

        }


        public double CalculateSalary()
        {
            if (employee != null)
            {
                return this.CalculateSalary(employee);
            }
            else
            {
                return 0;
            }
        }

        public double CalculateSalary(IEmployee employee)
        {
            if (employee != null)
            {
                return this.CalculateSalary(employee, employee.EmploymentDate, DateTime.Now);
            }
            else
            {
                return 0;
            }

        }

        public abstract double CalculateSalary(double generalRate, double rateLimit, double rateIncriment, DateTime beginDate, DateTime endDate);

        public abstract double CalculateSalary(IEmployee employee, DateTime beginDate, DateTime endDate);
    }
}
