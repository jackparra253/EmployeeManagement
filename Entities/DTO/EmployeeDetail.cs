using Entities.ValueObject;

namespace Entities.DTO
{
    public class EmployeeDetail
    {
        public int EmployeeId { get; private set; }
        public string Name { get; private set; }
        public string LastName { get; private set; }
        public string TypeContract { get; private set; }
        public Money Salary { get; private set; }
        public Money AnnualSalary { get; private set; }
        public string RoleName { get; private set; }
        public string RoleDescriptrion { get; private set; }

        public EmployeeDetail(int employeeId, string name, string lastName, string typeContract, Money salary, Money annualSalary, string roleName, string roleDescriptrion)
        {
            EmployeeId = employeeId;
            Name = name;
            LastName = lastName;
            TypeContract = typeContract;
            Salary = salary;
            AnnualSalary = annualSalary;
            RoleName = roleName;
            RoleDescriptrion = roleDescriptrion;
        }
    }
}