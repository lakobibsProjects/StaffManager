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
        private IEmployee chief;
        ObservableCollection<Employee> subordinates;
        private ObservableCollection<int> subordinatesID;
        #endregion Fields

        #region Properties
        [Column(Name = "ID", IsDbGenerated = true, IsPrimaryKey = true, DbType = "INTEGER")]
        [Key]
        public int Id { get; set; }
        /// <summary>
        /// Name of employee
        /// </summary>
        [Column(Name = "EmployeeName", DbType = "VARCHAR")]
        public string Name
        {
            get { return name; }
            set { name = value; }
        }
        [Column(Name = "EmploymentDate", DbType = "VARCHAR")]
        public DateTime EmploymentDate
        {
            get { return employmentDate; }
            set { employmentDate = value; }
        }

        [Column(Name = "Salary", DbType = "REAL")]
        public double GeneralRate
        {
            get { return generalRate; }
            protected set { generalRate = value; }
        }

        [System.Data.Linq.Mapping.Association(Storage = "chief", ThisKey = "ChiefID")]
        public IEmployee Chief
        {
            get { return chief; }
            set { chief = value; }  //todo: change logic to make private or protected
        }
        //механизм для десериализации механизма расчета заработной платы
        public IWage Wage
        {
            get
            {
                switch (WageType)
                {
                    case "EmployeeWage":
                        return new EmployeeWage(this);
                        break;
                    case "ManagerWage":
                        return new ManagerWage(this);
                        break;
                    case "SalesmanWage":
                        return new SalesmanWage(this);
                    default:
                        throw new ArgumentException("Unhandled type of Wage");
                        break;
                }
            }

            set { Wage = value; }
        }
        [Column(Name = "WageType", DbType = "VARCHAR")]
        public string WageType { get; set; }
        //change later to enum
        //упрощение. сделано для улучшения взаимодействия с базой данных
        [Column(Name = "Position", DbType = "VARCHAR")]
        public string Position { get; set; }

        public int ChiefID { get; set; }
        [Column(Name = "CanBeChief", DbType = "INTEGER")]
        public bool CanBeChief { get; set; } = false;
        //public IWage WageType { get; set; }
        [System.Data.Linq.Mapping.Association(Storage = "subordinates", OtherKey = "ChiefID")]
        public ObservableCollection<int> SubordinatesID
        {
            get { return subordinatesID; }
            set { subordinatesID = value; }
        }
        public ObservableCollection<Employee> Subordinates { get { return subordinates; } set { subordinates = value; } }

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
        /*
        /// <summary>
        /// Add chief to employee
        /// </summary>
        /// <param name="chief">Chief of employee</param>
        public void AddChief(IEmployee chief)    //слишком сильная зависимость от наследуемого класса
        {
            if (this.Chief == null)
            {
                if (chief.CanBeChief)
                {
                    this.Chief = chief;
                }
                else
                {
                    throw new Exception("Target employee cannot have subordinates");
                }
            }
            else
            {
                throw new Exception("This employee have chief");
            }
        }
        /// <summary>
        /// Replace chief to employee or add new chief
        /// </summary>
        /// <param name="chief">Chief of employee</param>
        public void ReplaceChief(IEmployee chief)    //слишком сильная зависимость от наследуемого класса
        {
            if (chief.CanBeChief)
            {
                this.Chief = chief;
            }
            else
            {
                throw new Exception("Target employee cannot have subordinates");
            }

        }
        //упрощение. на данный момент реализована жесткая привязка к типу расчета заработной платы
        public double getWage()
        {
            switch (this.Position)
            {
                case "Employee":
                    return new EmployeeWage(this).CalculateWage();
                case "Manager":
                    return new ManagerWage(this).CalculateWage();
                case "Salesman":
                    return new SalesmanWage(this).CalculateWage();
                default:
                    return this.GeneralRate;
            }
        }

        public void AddSubordinate(IEmployee employee)
        {
            if (this.CanBeChief)
                employee.ReplaceChief(this);
        }

        public ObservableCollection<IEmployee> GetSubourdinates(IDBService db)
        {
            return db.GetSubordinates(this);
        }*/
    }
}
