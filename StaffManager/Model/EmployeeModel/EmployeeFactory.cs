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
            result.Position  = context.Positions.Where(p => p.Id == 4).FirstOrDefault();
            result.Salary = context.SalaryTypes.Where(s => s.Id == 4).FirstOrDefault();

            return result;
        }

        public Employee Manager(string name, double salary, DateTime employmentDate)
        {
            Employee result = new Employee(name, salary, employmentDate);
            result.CanBeChief = true;
            result.Position = context.Positions.Where(p => p.Id == 1).FirstOrDefault();
            result.Salary = context.SalaryTypes.Where(s => s.Id == 1).FirstOrDefault();
            result.Subordinates = new ObservableCollection<Employee>();

            return result;
        }

        public Employee Salesman(string name, double salary, DateTime employmentDate)
        {
            Employee result = new Employee(name, salary, employmentDate);
            result.CanBeChief = true;
            result.Position = context.Positions.Where(p => p.Id == 2).FirstOrDefault();
            result.Salary = context.SalaryTypes.Where(s => s.Id == 2).FirstOrDefault();
            result.Subordinates = new ObservableCollection<Employee>();

            return result;
        }
    }
}
