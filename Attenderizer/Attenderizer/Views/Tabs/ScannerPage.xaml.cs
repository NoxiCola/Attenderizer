using Attenderizer.Models;
using Attenderizer.Services;
using Attenderizer.ViewModels;
using Attenderizer.Views.ScanPages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Attenderizer.Views.Tabs
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ScannerPage : ContentPage
    {
        private IPageService _pageService;
        private IScannerService _scannerService;
        //private ScannerModel _scannerModel;
        //private ScannerViewModel _scannerViewModel;

        public ScannerPage()
        {
            InitializeComponent();
            //BindingContext = new ScannerViewModel();

            _scannerService = new ScannerService();
            _pageService = new PageService();
        }

        private void Handle_OnScanResult(ZXing.Result result)
        {
            Device.BeginInvokeOnMainThread(async () =>
            {
                _scanView.IsAnalyzing = false;
                CheckQRCode(result.Text);
            });
        }

        protected override void OnAppearing()
        {
            _scanView.IsAnalyzing = true;
        }


        private async void Handle_OnClick(object sender, EventArgs e)//manual entry
        {
            string result = await DisplayPromptAsync("Manual Entry", "Please enter a QR code");

            if (result != null)
            {
                CheckQRCode(result);
            }
        }

        private async void CheckQRCode(string value)//Main method
        {
            string result = await GetSavedQRCode();
            if (string.IsNullOrEmpty(result))
            {
                await _pageService.DisplayAlert("Uh Oh!", "Unable to Find Code! Please try again");
            }
            else if (result == value)
            {
                await Navigation.PushModalAsync(new SuccessPage());
            }
            else
            {
                await Navigation.PushModalAsync(new FailPage());
            }
        }

        private async Task<string> GetSavedQRCode()// talk to API
        {
            string code;
            var codeFromDB = await _scannerService.GetCodeAsync();
            if (codeFromDB.QRCode == null)
            {
                code = string.Empty;
            }
            else
            {
                code = codeFromDB.QRCode;
            }
            return code;
        }

        private async Task<bool> UpdateAttendance(int user, LoginModel login)// talk to API
        {
            return await _scannerService.UpdateAttendanceAsync(user, login);
        }
    }
}