using System.Collections.Generic;
using Entities;

namespace IData
{
    public interface IRoleServiceFake
    {
        List<Role> GetAll();
        Role Get(int idRole);
    }
}