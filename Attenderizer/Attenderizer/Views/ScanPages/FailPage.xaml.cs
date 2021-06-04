using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Attenderizer.Views.ScanPages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class FailPage : ContentPage
    {
        public FailPage()
        {
            InitializeComponent();
        }
        private void Handle_ExitPopUp(object sender, EventArgs e)
        {
            this.Navigation.PopModalAsync();
        }
    }
}