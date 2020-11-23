using System;
using System.Collections.Generic;
using System.Linq;
using Domain;
using Entities.Constant;
using Entities.DTO;
using Entities.ValueObject;
using IApplication;
using IData;

namespace Application
{
    public class EmployeeExternalQueryHandler : IEmployeeExternalQueryHandler
    {
        private readonly IEmployeeExternalService _employeeExternalService;

        public EmployeeExternalQueryHandler(IEmployeeExternalService employeeExternalService)
        {
            _employeeExternalService = employeeExternalService;
        }

        public List<EmployeeDetail> GetAll()
        {
            List<EmployeeExternal> employeeExternals = _employeeExternalService.GetAll();

            List<EmployeeDetail> employeeDetails = new List<EmployeeDetail>();

            employeeExternals.ForEach(employeeExternal =>
            {
                if (employeeExternal.ContractTypeName == "HourlySalaryEmployee")
                {
                    var hourlySalaryBase = new Money(employeeExternal.HourlySalary, Currency.USD);
                    var hourlySalaryContract = new HourlySalaryContract(hourlySalaryBase);

                    var employeeDetailTypeHourlyContract = new EmployeeDetail(employeeExternal.Id, employeeExternal.Name, string.Empty,
                        hourlySalaryContract.TypeContract, hourlySalaryContract.Salary,
                        hourlySalaryContract.AnnualSalary, employeeExternal.RoleName, employeeExternal.RoleDescription);

                    employeeDetails.Add(employeeDetailTypeHourlyContract);
                }

                if (employeeExternal.ContractTypeName == "MonthlySalaryEmployee")
                {
                    var salary = new Money(employeeExternal.MonthlySalary, Currency.USD); ;
                    MonthlySalaryContract monthlySalaryContract = new MonthlySalaryContract(salary);

                    var employee = new EmployeeDetail(employeeExternal.Id, employeeExternal.Name, string.Empty, monthlySalaryContract.TypeContract, monthlySalaryContract.Salary, monthlySalaryContract.AnnualSalary, employeeExternal.RoleName, employeeExternal.RoleDescription);

                    employeeDetails.Add(employee);
                }
                
            });

            return employeeDetails;
        }

        public EmployeeDetail GetById(int id)
        {
            List<EmployeeExternal> employeeExternals = _employeeExternalService.GetAll();

            var employeeExternal = employeeExternals.FirstOrDefault(employee => employee.Id == id);

            if (employeeExternal is null)
                throw new Exception($"Employee with id {id} not exist.");

            if (employeeExternal.ContractTypeName == "HourlySalaryEmployee")
            {
                var hourlySalaryBase = new Money(employeeExternal.HourlySalary, Currency.USD);
                var hourlySalaryContract = new HourlySalaryContract(hourlySalaryBase);

                return  new EmployeeDetail(employeeExternal.Id, employeeExternal.Name, string.Empty,
                    hourlySalaryContract.TypeContract, hourlySalaryContract.Salary,
                    hourlySalaryContract.AnnualSalary, employeeExternal.RoleName, employeeExternal.RoleDescription);

            }

            if (employeeExternal.ContractTypeName == "MonthlySalaryEmployee")
            {
                var salary = new Money(employeeExternal.MonthlySalary, Currency.USD);
                MonthlySalaryContract monthlySalaryContract = new MonthlySalaryContract(salary);

                return new EmployeeDetail(employeeExternal.Id, employeeExternal.Name, string.Empty, monthlySalaryContract.TypeContract, monthlySalaryContract.Salary, monthlySalaryContract.AnnualSalary, employeeExternal.RoleName, employeeExternal.RoleDescription);
            }

            return new EmployeeDetail(employeeExternal.Id, employeeExternal.Name, string.Empty, string.Empty, new Money(0m, Currency.USD), new Money(0m, Currency.USD), employeeExternal.RoleName, employeeExternal.RoleDescription);
        }
    }
}
