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
    public class AddChiefViewModel
    {
        #region Fields
        private StaffContext db;
        private readonly DelegateCommand cancelCommand;
        private readonly DelegateCommand addCommand;
        #endregion

        #region Properties
        public ObservableCollection<Employee> Chiefs { get; set; }
        public Employee SelectedChief { get; set; }
        public ICommand CancelCommand => cancelCommand;
        public ICommand AddCommand => addCommand;
        #endregion

        public AddChiefViewModel()
        {
            db = new StaffContext();
            Chiefs = new ObservableCollection<Employee>(db.Employees.Where(e => e.CanBeChief));    //todo: except ChangedEmployee

            #region Commands
            addCommand = new DelegateCommand(OnAdd);
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

        private void OnAdd(object obj)
        {
            StaffViewModel.ChangedEmployee.Chief = SelectedChief;
            db.Employees.Where(e => e.Id == StaffViewModel.ChangedEmployee.Id).FirstOrDefault().Chief = db.Employees.Where(e => e.Id == SelectedChief.Id).FirstOrDefault();
            db.SaveChanges();
            OnCancel(obj);
        }
        #endregion
    }
}
