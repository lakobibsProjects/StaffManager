using StaffManager.Model.DBService;
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
    public interface IEmployee
    {
        IEmployee Chief { get; set; }
        DateTime EmploymentDate { get; set; }
        double GeneralRate { get; }
        int Id { get; set; }
        string Name { get; set; }
        Position Position { get; }
        bool CanBeChief { get; }
        Wage Wage { get; }
        ObservableCollection<Employee> Subordinates { get; set; }

        void AddSubordinate(IEmployee employee);
        double GetWage();
        void RemoveSubordinate(IEmployee employee);
    }
}
