using System.Collections.Generic;
using System.Linq;
using Entities;
using IData;

namespace Data
{
    public class RoleServiceFake : IRoleServiceFake
    {
        private List<Role> _roles = new List<Role>
        {
            new Role(1, "Administrator","a person responsible for the performance or management of administrative business operations"),
            new Role(2, "Contractor"," an individual or organization responsible for the construction of a building or other facility"),
            new Role(3, "Software developer","a person who writes computer programs"),
            new Role(4, "Video game developer","a person or business involved in video game development, the process of designing and creating games")

        };

        public List<Role> GetAll()
        {
            return _roles;
        }

        public Role Get(int idRole)
        {
            return _roles.Where(role => role.Id == idRole).FirstOrDefault();
        }
    }
}
