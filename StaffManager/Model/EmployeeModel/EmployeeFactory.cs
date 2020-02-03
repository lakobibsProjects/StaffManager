using StaffManager.Model.DBService;
using StaffManager.Model.PositionModel;
using StaffManager.Model.WageModel;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StaffManager.Model.EmployeeModel
{
    public class EmployeeFactory
    {
        StaffContext context = new StaffContext();
        public Employee GeneralEmployee(string name, double salary, DateTime employmentDate)
        {
            Employee result = new Employee(name, salary, employmentDate);
            result.CanBeChief = false;
            result.Position  = context.Positions.Find(0);
            result.Salary = context.SalaryTypes.Find(0);

            return result;
        }

        public Employee Manager(string name, double salary, DateTime employmentDate)
        {
            Employee result = new Employee(name, salary, employmentDate);
            result.CanBeChief = true;
            result.Position = context.Positions.Find(1);
            result.Salary = context.SalaryTypes.Find(1);
            result.Subordinates = new ObservableCollection<Employee>();

            return result;
        }

        public Employee Salesman(string name, double salary, DateTime employmentDate)
        {
            Employee result = new Employee(name, salary, employmentDate);
            result.CanBeChief = true;
            result.Position = context.Positions.Find(2);
            result.Salary = context.SalaryTypes.Find(2);
            result.Subordinates = new ObservableCollection<Employee>();

            return result;
        }
    }
}
