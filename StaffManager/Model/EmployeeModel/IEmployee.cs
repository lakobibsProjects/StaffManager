using StaffManager.Model.DBService;
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
        //change later to enum
        string Position { get; }
        int ChiefID { get; }
        bool CanBeChief { get; }
        IWage Wage { get; }
        string WageType { get; set; }

        /*void AddChief(IEmployee chief);
        void ReplaceChief(IEmployee chief);
        double getWage();
        ObservableCollection<IEmployee> Subordinates { get; set; }
        ObservableCollection<IEmployee> GetSubourdinates(IDBService db);
        void AddSubordinate(IEmployee employee);*/
    }
}
