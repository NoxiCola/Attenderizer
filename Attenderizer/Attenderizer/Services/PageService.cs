using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Attenderizer.Services
{
    class PageService : IPageService
    {
        public async Task DisplayAlert(string title, string message)
        {
            await Application.Current.MainPage.DisplayAlert(title, message, "Ok");
        }

        public async Task<string> DisplayQRPromptAsync(string title, string message)
        {
            return await Application.Current.MainPage.DisplayPromptAsync(title, message, "OK", "Cancel");
        }

        public async Task<bool> DisplayYesNoAlert(string title, string message)
        {
            return await Application.Current.MainPage.DisplayAlert(title, message, "Yes", "No");
        }

        public async Task<Page> PopAsync()
        {
            return await Application.Current.MainPage.Navigation.PopAsync();
        }

        public async Task PushAsync(Page page)
        {
            await Application.Current.MainPage.Navigation.PushAsync(page);
        }

        public async Task PushModalAsync(Page page)
        {
            await Application.Current.MainPage.Navigation.PushModalAsync(page);
        }
    }
}
