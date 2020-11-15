using Entities;

namespace Domain
{
    public class MonthlySalaryContract : ISalaryContract
    {
        public MonthlySalaryContract(Money salary)
        {
            TypeContract = Entities.TypeContract.MonthlySalary;
            Salary = salary;
            AnnualSalary = CalculatedAnnualSalary();
        }

        public string TypeContract { get; private set; }
        public Money Salary { get; private set; }
        public Money AnnualSalary { get; private set; }

        public Money CalculatedAnnualSalary()
        {
            decimal operationsToCalculateAnnualSalary = Salary.Amount * 12;
            AnnualSalary = new Money(operationsToCalculateAnnualSalary, Salary.Currency);
            return AnnualSalary;
        }
    }
}