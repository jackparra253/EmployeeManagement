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

            return CreateEmployeesDetails(employeeExternals);
        }

        private List<EmployeeDetail> CreateEmployeesDetails(List<EmployeeExternal> employeeExternals)
        {
            List<EmployeeDetail> employeeDetails = new List<EmployeeDetail>();

            employeeExternals.ForEach(employeeExternal =>
            {
                if (IsHourlySalaryEmployee(employeeExternal.ContractTypeName))
                {
                    var employeeDetailTypeHourlyContract = CreateHourlySalaryEmployee(employeeExternal);
                    employeeDetails.Add(employeeDetailTypeHourlyContract);
                }

                if (IsMonthlySalaryEmployee(employeeExternal.ContractTypeName))
                {
                    var employee = CreateMonthlySalaryEmployee(employeeExternal);
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

            if (IsHourlySalaryEmployee(employeeExternal.ContractTypeName))
                return CreateHourlySalaryEmployee(employeeExternal);

            if (IsMonthlySalaryEmployee(employeeExternal.ContractTypeName))
                return CreateMonthlySalaryEmployee(employeeExternal);

            return CreateEmployeeDetailDefault(employeeExternal);
        }

        private bool IsHourlySalaryEmployee(string contractTypeName)
        {
            return contractTypeName == "HourlySalaryEmployee";
        }

        private bool IsMonthlySalaryEmployee(string contractTypeName)
        {
            return contractTypeName == "MonthlySalaryEmployee";
        }

        private EmployeeDetail CreateHourlySalaryEmployee(EmployeeExternal employeeExternal)
        {
            var hourlySalaryBase = new Money(employeeExternal.HourlySalary, Currency.USD);
            var hourlySalaryContract = new HourlySalaryContract(hourlySalaryBase);

            return new EmployeeDetail(employeeExternal.Id, employeeExternal.Name, string.Empty,
                hourlySalaryContract.TypeContract, hourlySalaryContract.Salary,
                hourlySalaryContract.AnnualSalary, employeeExternal.RoleName, employeeExternal.RoleDescription);
        }

        private EmployeeDetail CreateMonthlySalaryEmployee(EmployeeExternal employeeExternal)
        {
            var salary = new Money(employeeExternal.MonthlySalary, Currency.USD);
            MonthlySalaryContract monthlySalaryContract = new MonthlySalaryContract(salary);

            return new EmployeeDetail(employeeExternal.Id, employeeExternal.Name, string.Empty, monthlySalaryContract.TypeContract, monthlySalaryContract.Salary, monthlySalaryContract.AnnualSalary, employeeExternal.RoleName, employeeExternal.RoleDescription);
        }

        private EmployeeDetail CreateEmployeeDetailDefault(EmployeeExternal employeeExternal)
        {
            return new EmployeeDetail(employeeExternal.Id, employeeExternal.Name, string.Empty, string.Empty, new Money(0m, Currency.USD), new Money(0m, Currency.USD), employeeExternal.RoleName, employeeExternal.RoleDescription);
        }
    }
}
