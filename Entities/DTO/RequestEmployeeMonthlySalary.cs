namespace Entities.DTO
{
    public class RequestEmployeeMonthlySalary: RequestEmployee
    {
        public string Name { get; private set; }
        public string LastName { get; private set; }
        public int IdRole { get; private set; }
        public decimal Amount { get; private set; }
        public string MonthlySalary { get; private set; }

        public RequestEmployeeMonthlySalary(string name, string lastName, int idRole, decimal amount) : base(name, lastName, idRole, amount)
        {
            Name = name;
            LastName = lastName;
            IdRole = idRole;
            Amount = amount;
            MonthlySalary = TypeContract.MonthlySalary;
        }
    }
}
