namespace Entities
{
    public class Employee
    {
        public Employee(string name, string lastName, ISalaryContract salaryContract)
        {
            Name = name;
            LastName = lastName;
            SalaryContract = salaryContract;
        }

        public string Name { get; private set; }
        public string LastName { get; private set; }
        public ISalaryContract SalaryContract { get; private set; }
    }

    public interface ISalaryContract
    {
        Money CalculatedAnnualSalary();
    }

}