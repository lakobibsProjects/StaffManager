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
            result.Position = "Employee";
            result.WageType = "EmployeeWage";
            //result.Wage = new EmployeeWage(result);

            return result;
        }

        public Employee Manager(string name, double salary, DateTime employmentDate)
        {
            Employee result = new Employee(name, salary, employmentDate);
            result.CanBeChief = true;
            result.Position = "Manager";
            result.WageType = "ManagerWage";
            //result.Wage = new ManagerWage(result);
            result.SubordinatesID = new ObservableCollection<int>();

            return result;
        }

        public Employee Salesman(string name, double salary, DateTime employmentDate)
        {
            Employee result = new Employee(name, salary, employmentDate);
            result.CanBeChief = true;
            result.Position = "Salesman";
            result.WageType = "SalesmanWage";
            //result.Wage = new SalesmanWage(result);
            result.SubordinatesID = new ObservableCollection<int>();

            return result;
        }
    }
}
