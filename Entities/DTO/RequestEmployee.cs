namespace Entities.DTO
{
    public class RequestEmployee
    {
        public string Name { get; private set; }
        public string LastName { get; private set; }
        public int IdRole { get; private set; }
        public decimal Amount { get; private set; }

        public RequestEmployee(string name, string lastName, int idRole, decimal amount)
        {
            Name = name;
            LastName = lastName;
            IdRole = idRole;
            Amount = amount;
        }
    }
}
