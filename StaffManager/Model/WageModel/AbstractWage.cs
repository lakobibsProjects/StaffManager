using StaffManager.Model.EmployeeModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StaffManager.Model.WageModel
{
    public abstract class AbstractWage : IWage
    {
        private IEmployee employee;
        private double rateIncrement;
        private double rateLimit;

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

        public AbstractWage(IEmployee employee)
        {
            this.employee = employee;
        }


        public double CalculateWage()
        {
            if (employee != null)
            {
                return this.CalculateWage(employee);
            }
            else
            {
                return 0;
            }
        }

        public double CalculateWage(IEmployee employee)
        {
            if (employee != null)
            {
                return this.CalculateWage(employee, employee.EmploymentDate, DateTime.Now);
            }
            else
            {
                return 0;
            }

        }

        public abstract double CalculateWage(double generalRate, double rateLimit, double rateIncriment, DateTime beginDate, DateTime endDate);

        public abstract double CalculateWage(IEmployee employee, DateTime beginDate, DateTime endDate);
    }
}
