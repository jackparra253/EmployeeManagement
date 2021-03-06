﻿using Domain;
using Entities;
using Entities.Constant;
using Entities.DTO;
using Entities.ValueObject;
using IApplication;
using IData;

namespace Application
{
    public class EmployeeHourlySalary:  EmployeeSalary, IEmployeeHourlySalary
    {
        private readonly IEmployeeService _employeeService;

        public EmployeeHourlySalary(IEmployeeService employeeService)
        {
            _employeeService = employeeService;
        }

        public override void Create(RequestEmployee requestEmployee)
        {
            var requestEmployeeHourlySalary = new RequestEmployeeHourlySalary(requestEmployee);

            var salary = new Money(requestEmployeeHourlySalary.Amount, Currency.USD);

            var hourlySalaryContract = new HourlySalaryContract(salary);

            Employee employee = new Employee(requestEmployeeHourlySalary.Name, requestEmployeeHourlySalary.LastName, hourlySalaryContract.TypeContract, hourlySalaryContract.Salary, hourlySalaryContract.AnnualSalary, requestEmployeeHourlySalary.IdRole);

            _employeeService.Save(employee);
        }
    }
}