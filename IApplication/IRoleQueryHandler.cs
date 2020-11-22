using System.Collections.Generic;
using Entities;

namespace IApplication
{
    public interface IRoleQueryHandler
    {
        List<Role> GetAll();
    }
}