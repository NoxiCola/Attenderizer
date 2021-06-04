using Attenderizer.Models;
using System.Threading.Tasks;

namespace Attenderizer.Services
{
    interface IScannerService
    {
        Task<ScannerModel> GetCodeAsync();
        Task<bool> UpdateAttendanceAsync(int userName, LoginModel model);
    }
}