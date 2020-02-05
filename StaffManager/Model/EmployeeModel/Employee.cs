using PropertyChanged;
using StaffManager.Model.DBService;
using StaffManager.Model.WageModel;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Data.Linq.Mapping;
using System.Data.SQLite;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StaffManager.Model.PositionModel;

namespace StaffManager.Model.EmployeeModel
{
    /// <summary>
    /// General functionality for employee
    /// </summary>
    [AddINotifyPropertyChangedInterface]
    [Table(Name = "Employees")]
    public class Employee : IEmployee
    {
        #region Fields
        private string name;
        private DateTime employmentDate;
        private double generalRate;
        private Employee chief;
        ObservableCollection<Employee> subordinates = new ObservableCollection<Employee>();
        #endregion Fields

        #region Properties
        public int Id { get; set; }
        /// <summary>
        /// Name of employee
        /// </summary>
        public string Name
        {
            get { return name; }
            set { name = value; }
        }
        public DateTime EmploymentDate
        {
            get { return employmentDate; }
            set { employmentDate = value; }
        }
        public double GeneralRate
        {
            get { return generalRate; }
            set { generalRate = value; }
        }
        public int? ChiefId { get; set; }
        public Employee Chief
        {
            get { return chief; }
            set
            {
                if (value == null)
                    return;

                if (value.CanBeChief)
                {
                    chief = value;
                    value.Subordinates.Add(this);
                }
                else
                {
                    throw new Exception("Target employee cannot have subordinates");
                }
            }  //todo: change logic to make private or protected
        }
        public virtual Salary Salary { get; set; }
        public virtual Position Position { get; set; }
        public bool CanBeChief { get; set; } = false;
        public ObservableCollection<Employee> Subordinates { get { return CanBeChief? subordinates : null; } set { subordinates = value; } }

        //add funcionality in future
        /*
        public string Login { get; set; }
        public string Password { get; set; }
        */
        #endregion Properties

        #region Constructors
        /// <summary>
        /// Create instance of employee
        /// </summary>
        /// <param name="name">Name of employee</param>
        /// <param name="rate">General rate of employee</param>
        /// <param name="employmentDate">Employment date of employee</param>
        public Employee(string name, double rate, DateTime employmentDate)
        {
            this.name = name;
            this.generalRate = rate;
            this.employmentDate = employmentDate;
        }

        /// <summary>
        /// Empty constructor for DB
        /// </summary>
        public Employee()
        {
        }
        #endregion Constructors

        #region Methods
        public double GetWage()
        {
            return Salary == null? this.GeneralRate : Salary.CalculateSalary(this);
        }
        public void AddSubordinate(Employee employee)
        {
            if (this.CanBeChief)
            {
                employee.Chief = this;
                Subordinates.Add(employee as Employee);
            }
        }
        public void RemoveSubordinate(Employee employee)
        {
            if (this.CanBeChief)
            {
                employee.Chief = null;
                Subordinates.Remove(employee as Employee);
            }
        }
        #endregion       
    }
}
