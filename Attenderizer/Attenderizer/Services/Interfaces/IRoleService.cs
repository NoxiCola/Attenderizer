using Attenderizer.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Attenderizer.Services
{
    public interface IRoleService
    {
        Task<List<RoleModel>> GetRoleAsync();
        //Task<List<LoginModel>> GetRoleAsync();
    }
}