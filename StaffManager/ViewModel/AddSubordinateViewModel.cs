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
    public class AddSubordinateViewModel
    {
        #region Fields
        private IDBService db;
        private readonly DelegateCommand cancelCommand;
        private readonly DelegateCommand addCommand;
        private readonly DelegateCommand addAndCloseCommand;
        #endregion

        #region Properties
        public string Name { get; set; }
        public DateTime EmoploymentDate { get; set; }
        public int Rate { get; set; }
        public string Position { get; set; }
        public ObservableCollection<Employee> Chiefs { get; set; }
        public Employee SelectedEmployee { get; set; }
        public ICommand CancelCommand => cancelCommand;

        public ICommand AddCommand => addCommand;
        public ICommand AddAndCloseCommand => addAndCloseCommand;
        #endregion

        public AddSubordinateViewModel()
        {
            db = new ObservableCollectionService();
            //todo: except ChangedEmployee and chiefs all levels of ChangedEmployee
            Chiefs = new ObservableCollection<Employee>(db.GetEmployees().Where(e => e.CanBeChief));

            #region Commands
            addCommand = new DelegateCommand(OnAdd);
            cancelCommand = new DelegateCommand(OnCancel);
            addAndCloseCommand = new DelegateCommand(OnAddAndClose);
            #endregion
        }


        #region Commands
        private void OnAddAndClose(object obj)
        {
            OnAdd(new Object());
            OnCancel(obj);
        }

        private void OnCancel(object obj)
        {
            Window current = (obj as Window);
            if (current != null)
            {
                current.Close();
            }
        }

        private void OnAdd(object obj)
        {
            if (StaffViewModel.ChangedEmployee.CanBeChief)
            {
                db.AddSubordinate(StaffViewModel.ChangedEmployee, SelectedEmployee);
            }
        }
        #endregion
    }
}
