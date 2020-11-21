namespace Entities.DTO
{
    public class EmployeeExternal
    {
        public int Id { get; private set; }
        public string Name { get; private set; }
        public string ContractTypeName { get; private set; }
        public int RoleId { get; private set; }
        public string RoleName { get; private set; }
        public string RoleDescription { get; private set; }
        public decimal HourlySalary { get; private set; }
        public decimal MonthlySalary { get; private set; }

        public EmployeeExternal(int id, string name, string contractTypeName, int roleId, string roleName, string roleDescription, decimal hourlySalary, decimal monthlySalary)
        {
            Id = id;
            Name = name;
            ContractTypeName = contractTypeName;
            RoleId = roleId;
            RoleName = roleName;
            RoleDescription = roleDescription;
            HourlySalary = hourlySalary;
            MonthlySalary = monthlySalary;
        }
    }
}
