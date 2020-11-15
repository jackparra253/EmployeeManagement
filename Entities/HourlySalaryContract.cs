namespace Entities
{
    public class HourlySalaryContract
    {
        public HourlySalaryContract(Money salary)
        {
            TypeContract = Entities.TypeContract.HourlySalary;
            Salary = salary;
            AnnualSalary = CalculatedAnnualSalary();
        }

        public string TypeContract { get; private set; }
        public Money Salary { get; private set; }
        public Money AnnualSalary { get; private set; }


        public Money CalculatedAnnualSalary()
        {
            AnnualSalary = new Money(120 * Salary.Amount * 12, Salary.Currency);
            return AnnualSalary;
        }
    }
}