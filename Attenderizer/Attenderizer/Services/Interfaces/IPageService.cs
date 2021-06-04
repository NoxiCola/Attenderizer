using System.Threading.Tasks;
using Xamarin.Forms;

namespace Attenderizer.Services
{
    interface IPageService
    {
        Task DisplayAlert(string title, string message);
        Task DisplayPromptAsync(string title, string message);
        Task<Page> PopAsync();
        Task PushAsync(Page page);
        Task PushModalAsync(Page page);
    }
}