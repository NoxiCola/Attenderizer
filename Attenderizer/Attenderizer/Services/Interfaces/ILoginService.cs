using Attenderizer.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Attenderizer.Services
{
    interface ILoginService
    {
        Task<List<LoginModel>> GetListAsync();
        Task<LoginModel> GetUserAsync(int? url);
    }
}