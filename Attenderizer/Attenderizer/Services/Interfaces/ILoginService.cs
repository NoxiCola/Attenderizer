using Attenderizer.Models;
using System.Threading.Tasks;

namespace Attenderizer.Services
{
    interface ILoginService
    {
        Task<LoginModel> GetUserAsync(int url);
    }
}