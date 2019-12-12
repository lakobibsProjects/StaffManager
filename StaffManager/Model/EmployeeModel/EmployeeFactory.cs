using StaffManager.Model.PositionModel;
using StaffManager.Model.WageModel;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StaffManager.Model.EmployeeModel
{
    public class EmployeeFactory
    {
        public Employee GeneralEmployee(string name, double salary, DateTime employmentDate)
        {
            Employee result = new Employee(name, salary, employmentDate);
            result.CanBeChief = false;
            result.Position = new Position() { ID = 0, Name = "Employee" };
            result.Wage = new Wage(result, 0.03, 0.3);

            return result;
        }

        public Employee Manager(string name, double salary, DateTime employmentDate)
        {
            Employee result = new Employee(name, salary, employmentDate);
            result.CanBeChief = true;
            result.Position = new Position() { ID = 1, Name = "Manager" };
            result.Wage = new Wage(result, 0.05, 0.4, true, false, 0.005);
            result.Subordinates = new ObservableCollection<Employee>();

            return result;
        }

        public Employee Salesman(string name, double salary, DateTime employmentDate)
        {
            Employee result = new Employee(name, salary, employmentDate);
            result.CanBeChief = true;
            result.Position = new Position() { ID = 2, Name = "Salesman" };
            result.Wage = new Wage(result, 0.01, 0.35, true, true, 0.003);
            result.Subordinates = new ObservableCollection<Employee>();

            return result;
        }
    }
}
