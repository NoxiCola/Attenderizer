using Attenderizer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Attenderizer.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MasterPage : TabbedPage
    {
        private string scan = "Scan";
        private string role = "Role";
        private LoginModel login = new LoginModel(); 
        public MasterPage(LoginModel model)
        {

            this.CurrentPageChanged += TabbedPage_CurrentPageChanged;

            InitializeComponent();
            NavigationPage.SetHasNavigationBar(this, true);
            login = model;
            //login = model;

        }

        private void TabbedPage_CurrentPageChanged(object sender, EventArgs e)//adds title name on navbar
        {
            if (CurrentPage == Children[0])
            {
                string name = login.FirstName;
                this.Title = name;
                
            }
            else
            {
                this.Title = role;
            }
        }

        private void Handle_OnClicked(object sender, EventArgs e)
        {
            //await Navigation.PushAsync(new SettingsPage());
        }
    }
}