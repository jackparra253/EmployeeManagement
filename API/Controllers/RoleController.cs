using System.Collections.Generic;
using Entities;
using IApplication;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class RoleController : ControllerBase
    {
        private readonly IRoleQueryHandler _roleQueryHandler;

        public RoleController(IRoleQueryHandler roleQueryHandler)
        {
            _roleQueryHandler = roleQueryHandler;
        }

        public List<Role> GetAll()
        {
            return _roleQueryHandler.GetAll();
        }
    }
}
