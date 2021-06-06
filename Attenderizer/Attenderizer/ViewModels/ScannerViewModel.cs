using Attenderizer.Models;
using Attenderizer.Services;
using Attenderizer.Views;
using Attenderizer.Views.ScanPages;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;
using ZXing;

namespace Attenderizer.ViewModels 
{
    public class ScannerViewModel 
    {
        private IPageService _pageService;
        private IScannerService _scannerService;
        LoginModel _loginModel = new LoginModel();

        public ICommand ScanCommand { get; set; }

        private bool _isAnalyzing = true;
        public bool IsAnalyzing
        {
            get { return _isAnalyzing; }
            set
            {
                _isAnalyzing = value;
                //if (!Equals(_isAnalyzing, value))
                //{
                //    _isAnalyzing = value;
                //}
            }
        }

        private bool _isScanning = true;
        public bool IsScanning
        {
            get { return _isScanning; }
            set
            {
                _isScanning = value;
                //if (!Equals(_isScanning, value))
                //{
                //    _isScanning = value;
                //}
            }
        }
        private string qrcode = string.Empty;
        public string QRCode
        {
            get { return qrcode; }
            set { qrcode = value; }
        }

        private string qrcodeDB = string.Empty;
        public string QRCodeDB
        {
            get { return qrcodeDB; }
            set { qrcodeDB = value; }
        }
        public Result Result { get; set; }

        

        public ScannerViewModel()
        {
            _scannerService = new ScannerService();
            _pageService = new PageService();

            ScanCommand = new Command(async () => await OnScan());
        }

        private async Task OnScan()//Open a new page instead of a display prompt. IsAnalysing is still true
        {
            var qrcode = await _pageService.DisplayQRPromptAsync("Manual Entry", "Please enter the QR Code");
            if (qrcode != null)
            {
                await OnQRScan(qrcode);
            }
            
        }

        public async Task OnQRScan(string qrcode)
        {
            string savedQRCode = await GetSavedQRCode();

            if (qrcode == savedQRCode)
            {
                await _pageService.PushModalAsync(new SuccessPage());

                _loginModel = new LoginModel
                {
                    Id = MasterPage.login.Id,
                    Username = MasterPage.login.Username,
                    Password = MasterPage.login.Password,
                    FirstName = MasterPage.login.FirstName,
                    LastName = MasterPage.login.LastName,
                    IsAbsent = false
                };

                bool response = await UpdateAttendance(MasterPage.login.Username, _loginModel);
            }
            else
            {
                await _pageService.PushModalAsync(new FailPage());
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
