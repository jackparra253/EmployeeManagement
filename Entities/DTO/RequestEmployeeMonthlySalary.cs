namespace Entities.DTO
{
    public class RequestEmployeeMonthlySalary: RequestEmployee
    {
        public string Name { get; private set; }
        public string LastName { get; private set; }
        public int IdRole { get; private set; }
        public decimal Amount { get; private set; }
        public string MonthlySalary { get; private set; }

        public RequestEmployeeMonthlySalary(RequestEmployee requestEmployee) : base(requestEmployee.Name, requestEmployee.LastName, requestEmployee.IdRole, requestEmployee.Amount)
        {
            Name = requestEmployee.Name;
            LastName = requestEmployee.LastName;
            IdRole = requestEmployee.IdRole;
            Amount = requestEmployee.Amount;
            MonthlySalary = TypeContract.MonthlySalary;
        }
    }
}
