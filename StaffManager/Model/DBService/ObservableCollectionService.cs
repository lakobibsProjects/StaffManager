using PropertyChanged;
using StaffManager.Model.EmployeeModel;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StaffManager.Model.DBService
{
    //это прокси-класс, имитирующий подключение к базе данных.
    //возможные ошибки не обработаны в должной мере.
    [AddINotifyPropertyChangedInterface]
    public class ObservableCollectionService : IDBService
    {
        private ObservableCollection<Employee> employees;

        public ObservableCollectionService()
        {
            employees = new ObservableCollection<Employee>();
            InitializeCollection();
        }
        #region IDBService methods
        public void AddChief(Employee chief, Employee subordinate)
        {
            if (employees.Contains(chief) && employees.Contains(subordinate))
            {
                employees.Where(e => e.Id == subordinate.Id).FirstOrDefault().Chief.Id = chief.Id;
                employees.Where(e => e.Id == chief.Id).FirstOrDefault().Subordinates.Add(subordinate);
            }
        }

        public void AddEmployee(Employee employee)
        {
            employees.Add(employee);
        }

        public void AddSubordinate(Employee chief, Employee subordinate)
        {
            if (employees.Contains(chief) && employees.Contains(subordinate))
            {
                employees.Where(e => e.Id == subordinate.Id).FirstOrDefault().Chief.Id = chief.Id;
                employees.Where(e => e.Id == chief.Id).FirstOrDefault().Subordinates.Add(subordinate);
            }
        }

        public void ChangeEmployee(Employee employee)
        {
            throw new NotImplementedException();
        }

        public ObservableCollection<Employee> GetEmployees()
        {
            return employees;
        }

        public ObservableCollection<Employee> GetSubordinates(Employee employee)
        {
            return new ObservableCollection<Employee>(employees.Where(e => e.Chief.Id == employee.Id));
        }

        public double GetSummaryWage()
        {
            return employees.Sum(e => e.Salary.CalculateSalary(e));
        }

        public void RemoveChief(Employee subordinate)
        {
            if (employees.Contains(employees.Where(e => e.Id == subordinate.Id).FirstOrDefault().Chief) && employees.Contains(subordinate))
            {
                employees.Where(e => e.Id == subordinate.Chief.Id).FirstOrDefault().Subordinates.Remove(subordinate);
                employees.Where(e => e.Id == subordinate.Id).FirstOrDefault().Chief.Id = -1;
            }
        }

        public void RemoveEmployee(Employee employee)
        {
            if (employees.Contains(employee))
            {
                employees.Remove(employee);
            }
        }

        public void RemoveSubordinate(Employee chief, Employee subordinate)
        {
            if (employees.Contains(employees.Where(e => e.Id == subordinate.Id).FirstOrDefault().Chief) && employees.Contains(subordinate))
            {
                employees.Where(e => e.Id == subordinate.Chief.Id).FirstOrDefault().Subordinates.Remove(subordinate);
                employees.Where(e => e.Id == subordinate.Id).FirstOrDefault().Chief.Id = -1;
            }
        }
        #endregion

        private void InitializeCollection()
        {
            EmployeeFactory factory = new EmployeeFactory();

            #region Inialize employees
            Employee employeeZero = factory.GeneralEmployee("employeeZero", 20000, new DateTime(2012, 7, 13));
            employeeZero.Id = 0;
            Employee employeeOne = factory.GeneralEmployee("employeeOne", 15000, new DateTime(2014, 12, 3));
            employeeOne.Id = 1;
            Employee employeeTwo = factory.GeneralEmployee("employeeTwo", 17300, new DateTime(2019, 10, 6));
            employeeTwo.Id = 2;
            Employee employeeThree = factory.GeneralEmployee("employeeThree", 12000, new DateTime(2014, 4, 7));
            employeeThree.Id = 3;
            Employee employeeFour = factory.GeneralEmployee("employeeFour", 18000, new DateTime(2015, 12, 5));
            employeeFour.Id = 4;
            Employee employeeFive = factory.GeneralEmployee("employeeFive", 27000, new DateTime(2016, 3, 22));
            employeeFive.Id = 5;
            Employee employeeSix = factory.GeneralEmployee("employeeSix", 23000, new DateTime(2017, 11, 12));
            employeeSix.Id = 6;
            Employee employeeSeven = factory.GeneralEmployee("employeeSeven", 13500, new DateTime(2012, 8, 2));
            employeeSeven.Id = 7;
            Employee employeeEight = factory.GeneralEmployee("employeeEight", 16000, new DateTime(2011, 10, 11));
            employeeEight.Id = 8;
            Employee employeeNine = factory.GeneralEmployee("employeeNine", 17000, new DateTime(2016, 3, 17));
            employeeNine.Id = 9;
            Employee employeeTen = factory.GeneralEmployee("employeeTen", 19000, new DateTime(2015, 7, 22));
            employeeTen.Id = 10;
            Employee employeeEleven = factory.GeneralEmployee("employeeEleven", 15000, new DateTime(2015, 4, 3));
            employeeEleven.Id = 11;
            Employee employeeTwelve = factory.GeneralEmployee("employeeTwelve", 21700, new DateTime(2016, 8, 4));
            employeeTwelve.Id = 12;

            Employee managerZero = factory.Manager("managerZero", 20000, new DateTime(2016, 11, 3));
            managerZero.Id = 13;
            Employee managerOne = factory.Manager("managerOne", 20000, new DateTime(2012, 10, 25));
            managerOne.Id = 14;
            Employee managerTwo = factory.Manager("managerTwo", 20000, new DateTime(2019, 5, 4));
            managerTwo.Id = 15;
            Employee managerThree = factory.Manager("managerThree", 20000, new DateTime(2011, 7, 12));
            managerThree.Id = 16;
            Employee managerFour = factory.Manager("managerFour", 20000, new DateTime(2012, 2, 20));
            managerFour.Id = 17;

            Employee salesmanZero = factory.Salesman("salesmanZero", 20000, new DateTime(2014, 11, 19));
            salesmanZero.Id = 18;
            Employee salesmanOne = factory.Salesman("salesmanOne", 20000, new DateTime(2014, 1, 22));
            salesmanOne.Id = 19;
            Employee salesmanTwo = factory.Salesman("salesmanTwo", 20000, new DateTime(2015, 9, 7));
            salesmanTwo.Id = 20;
            #endregion

            #region Adding emloyees
            employees.Add(employeeZero);
            employees.Add(employeeOne);
            employees.Add(employeeTwo);
            employees.Add(employeeThree);
            employees.Add(employeeFour);
            employees.Add(employeeFive);
            employees.Add(employeeSix);
            employees.Add(employeeSeven);
            employees.Add(employeeEight);
            employees.Add(employeeNine);
            employees.Add(employeeTen);
            employees.Add(employeeEleven);
            employees.Add(employeeTwelve);
            employees.Add(managerZero);
            employees.Add(managerOne);
            employees.Add(managerTwo);
            employees.Add(managerThree);
            employees.Add(managerFour);
            employees.Add(salesmanZero);
            employees.Add(salesmanOne);
            employees.Add(salesmanTwo);
            #endregion

            #region Add subordinates
            AddSubordinate(managerZero, employeeZero);
            AddSubordinate(managerZero, employeeOne);
            AddSubordinate(managerOne, employeeTwo);
            AddSubordinate(managerOne, employeeThree);
            AddSubordinate(managerTwo, employeeFour);
            AddSubordinate(managerTwo, employeeFive);
            AddSubordinate(managerTwo, employeeSix);
            AddSubordinate(managerTwo, salesmanTwo);
            AddSubordinate(managerThree, managerOne);
            AddSubordinate(managerThree, managerTwo);
            AddSubordinate(managerThree, managerFour);
            AddSubordinate(managerFour, salesmanZero);
            AddSubordinate(managerFour, salesmanOne);
            AddSubordinate(managerFour, salesmanTwo);
            AddSubordinate(salesmanZero, employeeSeven);
            AddSubordinate(salesmanOne, managerTwo);
            AddSubordinate(salesmanZero, employeeEight);
            AddSubordinate(salesmanOne, employeeTen);
            AddSubordinate(salesmanZero, employeeNine);
            AddSubordinate(salesmanTwo, employeeEleven);
            AddSubordinate(salesmanTwo, employeeTwelve);
            #endregion
        }
    }
}
