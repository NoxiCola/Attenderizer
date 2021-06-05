using Attenderizer.Models;
using Attenderizer.Services;
using Attenderizer.Views;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace Attenderizer.ViewModels
{
    
    public class LoginViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        public ICommand LoginCommand { get;}

        private IPageService _pageService;
        private ILoginService _loginService;
        private LoginModel userModelFromDB = new LoginModel();


        private string username;
        public string Username 
        {
            get { return username; }
            set { username = value; } 
        }//Connects to Login Xaml Page as a Binding

        private string password;
        public string Password
        {
            get { return password; }
            set { password = value; }
        }//Connects to Login Xaml Page as a Binding

        public LoginViewModel()
        {
            _loginService = new LoginService();
            _pageService = new PageService();

            LoginCommand = new Command(async () => await Login());//Connects to Login Xaml Page as a Binding as a Command
        }

        private async Task Login()
        {
            if (!string.IsNullOrEmpty(username) && !string.IsNullOrEmpty(password))
            {
                //Convert Username string to int -Done-
                //establish connection with API -Done-
                //Validate if the user exists -Done-
                //Get account -Done-
                //Send account to MasterPage/Child pages
                bool success = int.TryParse(username, out int userNum);
                if (success)
                {
                    var userDB = await _loginService.GetUserAsync(userNum);

                    if (userDB == null)
                    {
                        await _pageService.DisplayAlert($"Uh Oh!", "User cannot be found. Please make sure you entered your details correctly");
                    }
                    else if (userDB.Password != password)
                    {
                        await _pageService.DisplayAlert("Uh Oh!", "The Username or Password are incorrect. Please try again");
                    }
                    else
                    {
                        userModelFromDB = userDB;
                        MasterPage.login = userModelFromDB;
                        await _pageService.PushModalAsync(new NavigationPage(new MasterPage()));
                    }
                }
                else
                {
                    await _pageService.DisplayAlert("Uh Oh!", "The Username has to be your stundent number!");
                }
            }
            else
            {
                await _pageService.DisplayAlert("Uh Oh!", "The Username or Password are incorrect. Please try again");
            }
        }
    }


}
