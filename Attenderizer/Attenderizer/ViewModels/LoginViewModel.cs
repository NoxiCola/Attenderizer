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
    
    public class LoginViewModel
    {
        public ICommand LoginCommand { get; }

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

        //Convert Username string to int -Done-
        //establish connection with API -Done-
        //Validate if the user exists -Done-
        //Get account -Done-

        private bool IsEmpty(string uname, string pword)//Empty field validation method
        {
            if (!string.IsNullOrEmpty(uname) && !string.IsNullOrEmpty(pword))
                return false;
            else
                return true;
        }

        private int? IsInteger(string uname)//Integer validation method
        {
            bool success = int.TryParse(uname, out int userNum);
            if (success)
                return userNum;
            else
                return null;   
        }


        private async Task Login()
        {
            if (IsEmpty(username, password))//if username or password or both fields are empty...
            {
                //Alert user that the fields are empty
                await _pageService.DisplayAlert("Uh Oh!", "The Username or Password fields are empty! Please fill them in.");
                return;//exit method
            }

            if (IsInteger(username) == null)//if username is not an integer
            {
                //Alert user that account cannot be found
                await _pageService.DisplayAlert("Uh Oh!", "The Username has to be your stundent number!");
                return;//exit method
            }

            var userDB = await _loginService.GetUserAsync(IsInteger(username));//Get user data from API by calling Login Service Class by passing the username

            if (userDB == null)//if user data request cannot be found
            {
                //Alert user that account cannot be found
                await _pageService.DisplayAlert($"Uh Oh!", "User cannot be found. Please make sure you entered your details correctly");
            }
            else if (userDB.Password != password)//if passwords do not match
            {
                //Alert user that passwords do not match
                await _pageService.DisplayAlert("Uh Oh!", "The Username or Password are incorrect. Please try again");
            }
            else
            {
                userModelFromDB = userDB;
                MasterPage.login = userModelFromDB;//save the user to the MasterPage or mainpage
                App.Current.MainPage = new NavigationPage(new MasterPage());//Set MasterPage as the new main page (no more accidental logouts with the back button)
            }
        }
    }


}
