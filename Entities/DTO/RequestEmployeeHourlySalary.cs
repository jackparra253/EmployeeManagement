namespace Entities.DTO
{
    public class RequestEmployeeHourlySalary: RequestEmployee
    {
        
        public string Name { get; private set; }
        public string LastName { get; private set; }
        public int IdRole { get; private set; }
        public decimal Amount { get; private set; }
        public string HourlySalary { get; private set; }

        public RequestEmployeeHourlySalary(RequestEmployee requestEmployee): base(requestEmployee.Name, requestEmployee.LastName, requestEmployee.IdRole, requestEmployee.Amount)
        {
            Name = requestEmployee.Name;
            LastName = requestEmployee.LastName;
            IdRole = requestEmployee.IdRole;
            Amount = requestEmployee.Amount;
            HourlySalary = TypeContract.HourlySalary;
        }
    }
}