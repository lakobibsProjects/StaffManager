using System.Collections.ObjectModel;
using StaffManager.Model.EmployeeModel;

namespace StaffManager.Model.DBService
{
    /// <summary>
    /// Unterface with general functional to operate with DB of staff
    /// </summary>
    public interface IDBService
    {
        void AddChief(Employee chief, Employee subordinate);
        void AddEmployee(Employee employee);
        void AddSubordinate(Employee chief, Employee subordinate);
        void ChangeEmployee(Employee employee);
        ObservableCollection<Employee> GetEmployees();
        ObservableCollection<Employee> GetSubordinates(Employee employee);
        void RemoveChief(Employee subordinate);
        void RemoveEmployee(Employee employee);
        void RemoveSubordinate(Employee chief, Employee subordinate);
        double GetSummaryWage();
    }
}