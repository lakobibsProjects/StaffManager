using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PropertyChanged;
using StaffManager.Model.EmployeeModel;

namespace StaffManager.Model.DBService
{
    [AddINotifyPropertyChangedInterface]
    public class SQLiteService : IDBService
    {
        private StaffContext context;
        public SQLiteService()
        {
            context = new StaffContext();
        }

        #region IDBService methods
        public void AddEmployee(Employee employee)
        {
            context.Employees.Add(employee as Employee);

            context.SaveChanges();
        }

        public void ChangeEmployee(Employee employee)
        {
            throw new NotImplementedException();
        }
        //todo: cannot find tables
        public ObservableCollection<Employee> GetEmployees()
        {
            var result = new ObservableCollection<Employee>(context.Employees);

            return result;
        }

        public ObservableCollection<Employee> GetSubordinates(Employee employee)
        {
            if (context.Employees.Contains(employee) && employee.CanBeChief)
            {
                return new ObservableCollection<Employee>(context.Employees.Where(e => e.Chief.Id == employee.Id));
            }
            else
            {
                throw new ArgumentException();
            }
        }

        public void AddSubordinate(Employee chief, Employee subordinate)
        {
            if (context.Employees.Contains(chief) && chief.CanBeChief)
            {
                Employee Chief = context.Employees.Where(c => c.Id == chief.Id).FirstOrDefault();
                Chief.Subordinates.Add(subordinate);
                subordinate.Chief = chief;
                context.SaveChanges();
            }
            else
            {
                throw new ArgumentException();
            }
        }

        public void RemoveSubordinate(Employee chief, Employee subordinate)
        {
            if (context.Employees.Contains(chief) && chief.CanBeChief && chief.Subordinates.Contains(subordinate))
            {
                Employee Chief = context.Employees.Where(c => c.Id == chief.Id).FirstOrDefault();
                Chief.Subordinates.Remove(subordinate);
                subordinate.Chief = null;
                context.SaveChanges();
            }
            else
            {
                throw new ArgumentException();
            }
        }

        public void AddChief(Employee chief, Employee subordinate)
        {
            if (context.Employees.Contains(chief as Employee) && chief.CanBeChief)
            {
                Employee Chief = context.Employees.Where(c => c.Id == chief.Id).FirstOrDefault();
                Chief.Subordinates.Add(subordinate);
                subordinate.Chief = chief;
                context.SaveChanges();
            }
            else
            {
                throw new ArgumentException();
            }
        }

        public void RemoveChief(Employee subordinate)
        {
            Employee Chief = context.Employees.Where(c => c.Id == subordinate.Chief.Id).FirstOrDefault();

            if (context.Employees.Contains(Chief) && Chief.CanBeChief && Chief.Subordinates.Contains(subordinate))
            {
                Chief.Subordinates.Remove(subordinate);
                subordinate.Chief = null;
                context.SaveChanges();
            }
            else
            {
                throw new ArgumentException();
            }
        }

        public void RemoveEmployee(Employee employee)
        {
            if (context.Employees.Contains(employee as Employee))
                context.Employees.Remove(employee as Employee);

            context.SaveChanges();
        }

        public double GetSummaryWage()
        {
            return context.Employees.Sum(e => e.Salary.CalculateSalary(e));
        }
        #endregion
    }
}
