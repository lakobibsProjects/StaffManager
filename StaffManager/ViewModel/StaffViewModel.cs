using PropertyChanged;
using StaffManager.Model.DBService;
using StaffManager.Model.EmployeeModel;
using StaffManager.View;
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
    public class StaffViewModel
    {
        #region Fields
        private readonly DelegateCommand addChiefCommand;
        private readonly DelegateCommand removeChiefCommand;
        private readonly DelegateCommand addSubordinateCommand;
        private readonly DelegateCommand removeSuborinateCommand;
        private readonly DelegateCommand addStuffCommand;
        private readonly DelegateCommand deleteStuffCommand;
        private readonly DelegateCommand exitCommand;
        private IDBService db;
        #endregion

        #region Properties
        public ObservableCollection<Employee> Employees { get; set; }
        public ObservableCollection<Employee> Subordinates
        {
            get
            {
                if (SelectedEmployee != null)
                    return db.GetSubordinates(SelectedEmployee);// (SelectedEmployee.CanBeChief) ? SelectedEmployee.Subordinates : null;
                return null;
            }
        }
        public static Employee ChangedEmployee { get; set; }
        public Employee SelectedEmployee { get; set; }
        public Employee SelectedSubordinate { get; set; }
        public double SelectedEmployeeWage
        {
            get
            {
                if (SelectedEmployee != null)                
                    return SelectedEmployee.Wage.CalculateWage(SelectedEmployee);
                return 0;
            }
        } 
        public double SelectedSubordinateWage
        {
            get
            {
                if (SelectedSubordinate != null)
                    return SelectedSubordinate.Wage.CalculateWage(SelectedSubordinate);
                return 0;
            }
        }
        public ICommand AddChiefCommand => addChiefCommand;
        public ICommand RemoveChiefCommand => removeChiefCommand;
        public ICommand AddSubordinateCommand => addSubordinateCommand;
        public ICommand RemoveSuborinateCommand => removeSuborinateCommand;
        public ICommand AddStuffCommand => addStuffCommand;
        public ICommand DeleteStuffCommand => deleteStuffCommand;
        public ICommand ExitCommand => exitCommand;
        public double TotalWage { get; private set; }
        #endregion

        #region Constructors
        public StaffViewModel()
        {
            db = new ObservableCollectionService();
            Employees = db.GetEmployees();
            TotalWage = db.GetSummaryWage();
            #region Commands
            addChiefCommand = new DelegateCommand(OnAddChief);
            removeChiefCommand = new DelegateCommand(OnRemoveChief);
            addSubordinateCommand = new DelegateCommand(OnAddSubordinate);
            removeSuborinateCommand = new DelegateCommand(OnRemoveSubordinate);
            addStuffCommand = new DelegateCommand(OnAddStuff);
            deleteStuffCommand = new DelegateCommand(OnDeleteStuff);
            exitCommand = new DelegateCommand(OnExit);
            #endregion
        }
        #endregion

        #region Commands
        private void OnExit(object obj)
        {
            Application.Current.Shutdown();
        }

        private void OnDeleteStuff(object obj)
        {
            db.RemoveEmployee(SelectedEmployee);
            ActualizeCollection();
        }

        private void OnAddStuff(object obj)
        {
            Window newEmployee = new AddEmployeeWindow();
            newEmployee.Show();
        }

        private void OnRemoveSubordinate(object obj)
        {
            if (ChangedEmployee.CanBeChief)
            {
                ActualizeCollection();
            }
            else
            {
                MessageBox.Show("This employee cannot have subordinates");
            }
        }

        private void OnAddSubordinate(object obj)
        {
            if (ChangedEmployee.CanBeChief)
            {
                Window newSubordinate = new AddSubordinateWindow();
                newSubordinate.Show();
                ActualizeCollection();
            }
            else
            {
                MessageBox.Show("This employee cannot have subordinates");
            }

        }

        private void OnRemoveChief(object obj)
        {
            db.RemoveChief(obj as Employee);
            ActualizeCollection();
        }

        private void OnAddChief(object obj)
        {
            Window addChief = new AddChiefWindow();
            addChief.Show();
            ActualizeCollection();
        }
        #endregion

        private void ActualizeCollection()
        {
            Employees = db.GetEmployees();
        }
    }
}
