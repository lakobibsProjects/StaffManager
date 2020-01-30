namespace StaffManager.Migrations
{
    using StaffManager.Model.EmployeeModel;
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<StaffManager.Model.DBService.StaffContext>
    {

        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        #region FillEmployeesTable
        private static StaffManager.Model.DBService.StaffContext context = new Model.DBService.StaffContext();
        IEnumerable<Employee> employees = new List<Employee>()
            {
                new Employee()
                {
                    Id = 0,
                    Name = "Employee Zero",
                    EmploymentDate = new DateTime(2015, 04, 12),
                    GeneralRate = 12000,
                    Position = context.Positions.FirstOrDefault(p => p.Id == 0),
                    Salary = context.SalaryTypes.FirstOrDefault(p => p.Id == 0),
                },
                new Employee()
                {
                    Id = 1,
                    Name = "Employee One",
                    EmploymentDate = new DateTime(2012, 06, 13),
                    GeneralRate = 17000,
                    Position = context.Positions.FirstOrDefault(p => p.Id == 0),
                    Salary = context.SalaryTypes.FirstOrDefault(p => p.Id == 0),
                },
                new Employee()
                {
                    Id = 2,
                    Name = "Employee Two",
                    EmploymentDate = new DateTime(2017, 12, 3),
                    GeneralRate = 22000,
                    Position = context.Positions.FirstOrDefault(p => p.Id == 0),
                    Salary = context.SalaryTypes.FirstOrDefault(p => p.Id == 0),
                },
                new Employee()
                {
                    Id = 3,
                    Name = "Employee Three",
                    EmploymentDate = new DateTime(2015, 04, 20),
                    GeneralRate = 13000,
                    Position = context.Positions.FirstOrDefault(p => p.Id == 0),
                    Salary = context.SalaryTypes.FirstOrDefault(p => p.Id == 0),
                },
                new Employee()
                {
                    Id = 4,
                    Name = "Employee Four",
                    EmploymentDate = new DateTime(2013, 03, 25),
                    GeneralRate = 19500,
                    Position = context.Positions.FirstOrDefault(p => p.Id == 0),
                    Salary = context.SalaryTypes.FirstOrDefault(p => p.Id == 0),
                },
                new Employee()
                {
                    Id = 5,
                    Name = "Employee Five",
                    EmploymentDate = new DateTime(2017, 01, 15),
                    GeneralRate = 19000,
                    Position = context.Positions.FirstOrDefault(p => p.Id == 0),
                    Salary = context.SalaryTypes.FirstOrDefault(p => p.Id == 0),
                },
                new Employee()
                {
                    Id = 6,
                    Name = "Employee Six",
                    EmploymentDate = new DateTime(2014, 09, 3),
                    GeneralRate = 17000,
                    Position = context.Positions.FirstOrDefault(p => p.Id == 0),
                    Salary = context.SalaryTypes.FirstOrDefault(p => p.Id == 0),
                },
                new Employee()
                {
                    Id = 7,
                    Name = "Employee Seven",
                    EmploymentDate = new DateTime(2017, 03, 3),
                    GeneralRate = 22000,
                    Position = context.Positions.FirstOrDefault(p => p.Id == 0),
                    Salary = context.SalaryTypes.FirstOrDefault(p => p.Id == 0),
                },
                new Employee()
                {
                    Id = 8,
                    Name = "Employee Eight",
                    EmploymentDate = new DateTime(2016, 07, 5),
                    GeneralRate = 20000,
                    Position = context.Positions.FirstOrDefault(p => p.Id == 0),
                    Salary = context.SalaryTypes.FirstOrDefault(p => p.Id == 0),
                },
                new Employee()
                {
                    Id = 9,
                    Name = "Employee Nine",
                    EmploymentDate = new DateTime(2017, 04, 3),
                    GeneralRate = 22000,
                    Position = context.Positions.FirstOrDefault(p => p.Id == 0),
                    Salary = context.SalaryTypes.FirstOrDefault(p => p.Id == 0),
                },
                new Employee()
                {
                    Id = 10,
                    Name = "Employee Ten",
                    EmploymentDate = new DateTime(2017, 09, 25),
                    GeneralRate = 17000,
                    Position = context.Positions.FirstOrDefault(p => p.Id == 0),
                    Salary = context.SalaryTypes.FirstOrDefault(p => p.Id == 0),
                },
                new Employee()
                {
                    Id = 11,
                    Name = "Employee Eleven",
                    EmploymentDate = new DateTime(2017, 11, 20),
                    GeneralRate = 20000,
                    Position = context.Positions.FirstOrDefault(p => p.Id == 0),
                    Salary = context.SalaryTypes.FirstOrDefault(p => p.Id == 0),
                },
                new Employee()
                {
                    Id = 12,
                    Name = "Employee Twelve",
                    EmploymentDate = new DateTime(2017, 05, 10),
                    GeneralRate = 19700,
                    Position = context.Positions.FirstOrDefault(p => p.Id == 0),
                    Salary = context.SalaryTypes.FirstOrDefault(p => p.Id == 0),
                },
                new Employee()
                {
                    Id = 13,
                    Name = "Employee Thirteen",
                    EmploymentDate = new DateTime(2017, 08, 3),
                    GeneralRate = 21300,
                    Position = context.Positions.FirstOrDefault(p => p.Id == 0),
                    Salary = context.SalaryTypes.FirstOrDefault(p => p.Id == 0),
                },
                new Employee()
                {
                    Id = 14,
                    Name = "Manager Zero",
                    EmploymentDate = new DateTime(2012, 03, 15),
                    GeneralRate = 42900,
                    Position = context.Positions.FirstOrDefault(p => p.Id == 1),
                    Salary = context.SalaryTypes.FirstOrDefault(p => p.Id == 1),
                    CanBeChief = true,

                },
                new Employee()
                {
                    Id = 15,
                    Name = "Manager One",
                    EmploymentDate = new DateTime(2016, 07, 12),
                    GeneralRate = 33200,
                    Position = context.Positions.FirstOrDefault(p => p.Id == 1),
                    Salary = context.SalaryTypes.FirstOrDefault(p => p.Id == 1),
                    CanBeChief = true
                },
                new Employee()
                {
                    Id = 16,
                    Name = "Manager Two",
                    EmploymentDate = new DateTime(2017, 01, 15),
                    GeneralRate = 33900,
                    Position = context.Positions.FirstOrDefault(p => p.Id == 1),
                    Salary = context.SalaryTypes.FirstOrDefault(p => p.Id == 1),
                    CanBeChief = true,
                },
                new Employee()
                {
                    Id = 17,
                    Name = "Manager Three",
                    EmploymentDate = new DateTime(2019, 08, 10),
                    GeneralRate = 30200,
                    Position = context.Positions.FirstOrDefault(p => p.Id == 1),
                    Salary = context.SalaryTypes.FirstOrDefault(p => p.Id == 1),
                    CanBeChief = true,
                },
                new Employee()
                {
                    Id = 18,
                    Name = "Salesman Zero",
                    EmploymentDate = new DateTime(2017, 03, 22),
                    GeneralRate = 31700,
                    Position = context.Positions.FirstOrDefault(p => p.Id == 2),
                    Salary = context.SalaryTypes.FirstOrDefault(p => p.Id == 2),
                    CanBeChief = true,
                },
                new Employee()
                {
                    Id = 19,
                    Name = "Salesman One",
                    EmploymentDate = new DateTime(2012, 04, 17),
                    GeneralRate = 27200,
                    Position = context.Positions.FirstOrDefault(p => p.Id == 2),
                    Salary = context.SalaryTypes.FirstOrDefault(p => p.Id == 2),
                    CanBeChief = true,
                },
                new Employee()
                {
                    Id = 20,
                    Name = "Salesman Two",
                    EmploymentDate = new DateTime(2013, 01, 22),
                    GeneralRate = 34700,
                    Position = context.Positions.FirstOrDefault(p => p.Id == 2),
                    Salary = context.SalaryTypes.FirstOrDefault(p => p.Id == 2),
                    CanBeChief = true,
                }
            };
        #endregion FillEmployeesTable

        protected override void Seed(StaffManager.Model.DBService.StaffContext context)
        {
            
            context.SalaryTypes.AddOrUpdate(w => w.Id,
                new Model.WageModel.Salary(null, 0.03, 0.3) { Id = 0, Name = "" },
                new Model.WageModel.Salary(null, 0.05, 0.4, true, false, 0.005) { Id = 1, Name = "" },
                new Model.WageModel.Salary(null, 0.01, 0.35, true, true, 0.003) { Id = 2, Name = "" }
                );
            context.Positions.AddOrUpdate(p => p.Id,
                new Model.PositionModel.Position() { Id = 0, Name = "General employee" },
                new Model.PositionModel.Position() { Id = 1, Name = "Manager" },
                new Model.PositionModel.Position() { Id = 2, Name = "Salesman" }
                );
            context.Employees.AddRange(employees);

            #region AddChiefs
            context.Employees.Where(e => e.Id == 1).FirstOrDefault().Chief = context.Employees.Where(e => e.Id == 15).FirstOrDefault();
            context.Employees.Where(e => e.Id == 2).FirstOrDefault().Chief = context.Employees.Where(e => e.Id == 15).FirstOrDefault();
            context.Employees.Where(e => e.Id == 3).FirstOrDefault().Chief = context.Employees.Where(e => e.Id == 17).FirstOrDefault();
            context.Employees.Where(e => e.Id == 4).FirstOrDefault().Chief = context.Employees.Where(e => e.Id == 21).FirstOrDefault();
            context.Employees.Where(e => e.Id == 5).FirstOrDefault().Chief = context.Employees.Where(e => e.Id == 21).FirstOrDefault();
            context.Employees.Where(e => e.Id == 6).FirstOrDefault().Chief = context.Employees.Where(e => e.Id == 17).FirstOrDefault();
            context.Employees.Where(e => e.Id == 7).FirstOrDefault().Chief = context.Employees.Where(e => e.Id == 18).FirstOrDefault();
            context.Employees.Where(e => e.Id == 8).FirstOrDefault().Chief = context.Employees.Where(e => e.Id == 20).FirstOrDefault();
            context.Employees.Where(e => e.Id == 9).FirstOrDefault().Chief = context.Employees.Where(e => e.Id == 19).FirstOrDefault();
            context.Employees.Where(e => e.Id == 10).FirstOrDefault().Chief = context.Employees.Where(e => e.Id == 19).FirstOrDefault();
            context.Employees.Where(e => e.Id == 11).FirstOrDefault().Chief = context.Employees.Where(e => e.Id == 20).FirstOrDefault();
            context.Employees.Where(e => e.Id == 12).FirstOrDefault().Chief = context.Employees.Where(e => e.Id == 15).FirstOrDefault();
            context.Employees.Where(e => e.Id == 13).FirstOrDefault().Chief = context.Employees.Where(e => e.Id == 15).FirstOrDefault();
            context.Employees.Where(e => e.Id == 14).FirstOrDefault().Chief = context.Employees.Where(e => e.Id == 15).FirstOrDefault();
            context.Employees.Where(e => e.Id == 15).FirstOrDefault().Chief = context.Employees.Where(e => e.Id == 18).FirstOrDefault();
            context.Employees.Where(e => e.Id == 16).FirstOrDefault().Chief = context.Employees.Where(e => e.Id == 19).FirstOrDefault();
            context.Employees.Where(e => e.Id == 17).FirstOrDefault().Chief = context.Employees.Where(e => e.Id == 21).FirstOrDefault();
            context.Employees.Where(e => e.Id == 19).FirstOrDefault().Chief = context.Employees.Where(e => e.Id == 16).FirstOrDefault();
            context.Employees.Where(e => e.Id == 20).FirstOrDefault().Chief = context.Employees.Where(e => e.Id == 16).FirstOrDefault();
            context.Employees.Where(e => e.Id == 21).FirstOrDefault().Chief = context.Employees.Where(e => e.Id == 16).FirstOrDefault();
            #endregion AddChiefs

            #region AddPositions
            context.Employees.Where(e => e.Id == 1).FirstOrDefault().Position = context.Positions.Where(p => p.Id == 0).FirstOrDefault();
            context.Employees.Where(e => e.Id == 2).FirstOrDefault().Position = context.Positions.Where(p => p.Id == 0).FirstOrDefault();
            context.Employees.Where(e => e.Id == 3).FirstOrDefault().Position = context.Positions.Where(p => p.Id == 0).FirstOrDefault();
            context.Employees.Where(e => e.Id == 4).FirstOrDefault().Position = context.Positions.Where(p => p.Id == 0).FirstOrDefault();
            context.Employees.Where(e => e.Id == 5).FirstOrDefault().Position = context.Positions.Where(p => p.Id == 0).FirstOrDefault();
            context.Employees.Where(e => e.Id == 6).FirstOrDefault().Position = context.Positions.Where(p => p.Id == 0).FirstOrDefault();
            context.Employees.Where(e => e.Id == 7).FirstOrDefault().Position = context.Positions.Where(p => p.Id == 0).FirstOrDefault();
            context.Employees.Where(e => e.Id == 8).FirstOrDefault().Position = context.Positions.Where(p => p.Id == 0).FirstOrDefault();
            context.Employees.Where(e => e.Id == 9).FirstOrDefault().Position = context.Positions.Where(p => p.Id == 0).FirstOrDefault();
            context.Employees.Where(e => e.Id == 10).FirstOrDefault().Position = context.Positions.Where(p => p.Id ==0).FirstOrDefault();
            context.Employees.Where(e => e.Id == 11).FirstOrDefault().Position = context.Positions.Where(p => p.Id ==0).FirstOrDefault();
            context.Employees.Where(e => e.Id == 12).FirstOrDefault().Position = context.Positions.Where(p => p.Id ==0).FirstOrDefault();
            context.Employees.Where(e => e.Id == 13).FirstOrDefault().Position = context.Positions.Where(p => p.Id ==0).FirstOrDefault();
            context.Employees.Where(e => e.Id == 14).FirstOrDefault().Position = context.Positions.Where(p => p.Id ==0).FirstOrDefault();
            context.Employees.Where(e => e.Id == 15).FirstOrDefault().Position = context.Positions.Where(p => p.Id ==1).FirstOrDefault();
            context.Employees.Where(e => e.Id == 16).FirstOrDefault().Position = context.Positions.Where(p => p.Id ==1).FirstOrDefault();
            context.Employees.Where(e => e.Id == 17).FirstOrDefault().Position = context.Positions.Where(p => p.Id ==1).FirstOrDefault();
            context.Employees.Where(e => e.Id == 18).FirstOrDefault().Position = context.Positions.Where(p => p.Id ==1).FirstOrDefault();
            context.Employees.Where(e => e.Id == 19).FirstOrDefault().Position = context.Positions.Where(p => p.Id ==2).FirstOrDefault();
            context.Employees.Where(e => e.Id == 20).FirstOrDefault().Position = context.Positions.Where(p => p.Id ==2).FirstOrDefault();
            context.Employees.Where(e => e.Id == 21).FirstOrDefault().Position = context.Positions.Where(p => p.Id ==2).FirstOrDefault();
            #endregion AddPositions

            #region AddSalaryTypes
            context.Employees.Where(e => e.Id == 1).FirstOrDefault().Salary = context.SalaryTypes.Where(p => p.Id == 0).FirstOrDefault();
            context.Employees.Where(e => e.Id == 2).FirstOrDefault().Salary = context.SalaryTypes.Where(p => p.Id == 0).FirstOrDefault();
            context.Employees.Where(e => e.Id == 3).FirstOrDefault().Salary = context.SalaryTypes.Where(p => p.Id == 0).FirstOrDefault();
            context.Employees.Where(e => e.Id == 4).FirstOrDefault().Salary = context.SalaryTypes.Where(p => p.Id == 0).FirstOrDefault();
            context.Employees.Where(e => e.Id == 5).FirstOrDefault().Salary = context.SalaryTypes.Where(p => p.Id == 0).FirstOrDefault();
            context.Employees.Where(e => e.Id == 6).FirstOrDefault().Salary = context.SalaryTypes.Where(p => p.Id == 0).FirstOrDefault();
            context.Employees.Where(e => e.Id == 7).FirstOrDefault().Salary = context.SalaryTypes.Where(p => p.Id == 0).FirstOrDefault();
            context.Employees.Where(e => e.Id == 8).FirstOrDefault().Salary = context.SalaryTypes.Where(p => p.Id == 0).FirstOrDefault();
            context.Employees.Where(e => e.Id == 9).FirstOrDefault().Salary = context.SalaryTypes.Where(p => p.Id == 0).FirstOrDefault();
            context.Employees.Where(e => e.Id == 10).FirstOrDefault().Salary = context.SalaryTypes.Where(p => p.Id == 0).FirstOrDefault();
            context.Employees.Where(e => e.Id == 11).FirstOrDefault().Salary = context.SalaryTypes.Where(p => p.Id == 0).FirstOrDefault();
            context.Employees.Where(e => e.Id == 12).FirstOrDefault().Salary = context.SalaryTypes.Where(p => p.Id == 0).FirstOrDefault();
            context.Employees.Where(e => e.Id == 13).FirstOrDefault().Salary = context.SalaryTypes.Where(p => p.Id == 0).FirstOrDefault();
            context.Employees.Where(e => e.Id == 14).FirstOrDefault().Salary = context.SalaryTypes.Where(p => p.Id == 0).FirstOrDefault();
            context.Employees.Where(e => e.Id == 15).FirstOrDefault().Salary = context.SalaryTypes.Where(p => p.Id == 1).FirstOrDefault();
            context.Employees.Where(e => e.Id == 16).FirstOrDefault().Salary = context.SalaryTypes.Where(p => p.Id == 1).FirstOrDefault();
            context.Employees.Where(e => e.Id == 17).FirstOrDefault().Salary = context.SalaryTypes.Where(p => p.Id == 1).FirstOrDefault();
            context.Employees.Where(e => e.Id == 18).FirstOrDefault().Salary = context.SalaryTypes.Where(p => p.Id == 1).FirstOrDefault();
            context.Employees.Where(e => e.Id == 19).FirstOrDefault().Salary = context.SalaryTypes.Where(p => p.Id == 2).FirstOrDefault();
            context.Employees.Where(e => e.Id == 20).FirstOrDefault().Salary = context.SalaryTypes.Where(p => p.Id == 2).FirstOrDefault();
            context.Employees.Where(e => e.Id == 21).FirstOrDefault().Salary = context.SalaryTypes.Where(p => p.Id == 2).FirstOrDefault();
            #endregion AddSalaryTypes
        }
    }
}
