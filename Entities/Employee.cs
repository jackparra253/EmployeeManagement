using Entities.ValueObject;

namespace Entities
{
    public class Employee
    {
        public Employee(string name, string lastName, string typeContract, Money salary, Money annualSalary, int idRole)
        {
            Name = name;
            LastName = lastName;
            TypeContract = typeContract;
            Salary = salary;
            AnnualSalary = annualSalary;
            IdRole = idRole;
        }

        private Employee() { }

        public int EmployeeId { get; private set; }
        public string Name { get; private set; }
        public string LastName { get; private set; }
        public string TypeContract { get; private set; }
        public Money Salary { get; private set; }
        public Money AnnualSalary { get; private set; }
        public int IdRole { get; private set; }
    }
}