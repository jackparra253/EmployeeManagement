using System.Collections.Generic;
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

    }
}
