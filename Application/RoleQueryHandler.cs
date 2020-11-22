using System.Collections.Generic;
using Entities;
using IApplication;
using IData;

namespace Application
{
    public class RoleQueryHandler : IRoleQueryHandler
    {
        private readonly IRoleServiceFake _roleService;

        public RoleQueryHandler(IRoleServiceFake roleService)
        {
            _roleService = roleService;
        }

        public List<Role> GetAll()
        {
            return _roleService.GetAll();
        }

    }
}
