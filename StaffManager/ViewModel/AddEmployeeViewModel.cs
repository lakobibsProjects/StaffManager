using PropertyChanged;
using StaffManager.Model.DBService;
using StaffManager.Model.EmployeeModel;
using StaffManager.ViewModel.Commands;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace StaffManager.ViewModel
{
    [AddINotifyPropertyChangedInterface]
    public class AddEmployeeViewModel
    {
        #region Fields
        private StaffContext db;
        private readonly DelegateCommand cancelCommand;
        private readonly DelegateCommand saveCommand;
        #endregion

        #region Properties
        public string Name { get; set; }
        public DateTime EmoploymentDate { get; set; }
        public int Rate { get; set; }
        public string Position { get; set; }
        public ICommand CancelCommand => cancelCommand;
        public ICommand SaveCommand => saveCommand;
        public ObservableCollection<string> PositionsList => new ObservableCollection<string>()
        {
            "Employee",
            "Manager",
            "Salesman"
        };
        #endregion

        public AddEmployeeViewModel()
        {
            db = new StaffContext();
            EmoploymentDate = DateTime.Now;

            #region Commands
            saveCommand = new DelegateCommand(OnSave);
            cancelCommand = new DelegateCommand(OnCancel);
            #endregion
        }

        #region Commands
        private void OnCancel(object obj)
        {
            Window current = (obj as Window);
            if (current != null)
            {
                current.Close();
            }
        }
        private void OnSave(object obj)
        {
            Employee employee = null;
            EmployeeFactory factory = new EmployeeFactory();
            switch (Position)
            {
                case "Employee":
                    employee = factory.GeneralEmployee(Name, Rate, EmoploymentDate);
                    break;
                case "Manager":
                    employee = factory.Manager(Name, Rate, EmoploymentDate);
                    break;
                case "Salesman":
                    employee = factory.Salesman(Name, Rate, EmoploymentDate);
                    break;
                default:
                    throw new ArgumentException("Unhandled position of employee");
            }

            if (employee != null)
            {
                db.Employees.Add(employee);
            }
            db.SaveChanges();
            OnCancel(obj);
        }
        #endregion
    }
}
