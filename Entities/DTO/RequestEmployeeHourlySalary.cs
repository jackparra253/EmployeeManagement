namespace Entities.DTO
{
    public class RequestEmployeeHourlySalary
    {
        
        public string Name { get; private set; }
        public string LastName { get; private set; }
        public int IdRole { get; private set; }
        public decimal Amount { get; private set; }
        public string HourlySalary { get; private set; }

        public RequestEmployeeHourlySalary(string name, string lastName, in int idRole, decimal amount, string hourlySalary)
        {
        
            Name = name;
            LastName = lastName;
            IdRole = idRole;
            Amount = amount;
            HourlySalary = hourlySalary;
        }
    }
}