using Attenderizer.Models;
using Attenderizer.ViewModels;
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
        
        private ScannerViewModel _scannerViewModel = new ScannerViewModel();
        public MasterPage()
        {

            this.CurrentPageChanged += TabbedPage_CurrentPageChanged;

            InitializeComponent();
            NavigationPage.SetHasNavigationBar(this, true);
        }

        private void TabbedPage_CurrentPageChanged(object sender, EventArgs e)//adds title name on navbar
        {
            if (CurrentPage == Children[0])
            {

                this.Title = scan;
                
            }
            else
            {
                this.Title = role;
            }
        }
    }
}