using Attenderizer.Services;
using Attenderizer.Views;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace Attenderizer.ViewModels
{
    public class LogoutViewModel
    {
        private IPageService _pageService;
        public ICommand LogoutCommand { get; }
        public LogoutViewModel()
        {
            _pageService = new PageService();
            LogoutCommand = new Command(async () => await Logout());
        }

        private async Task Logout()
        {
            var answer = await _pageService.DisplayYesNoAlert("Logout?", "Are you sure you want to Logout?");
            if (answer == true)
            {
                Application.Current.MainPage = new LoginPage();
            }
            else
            {
                return;
            }
        }
    }
}
