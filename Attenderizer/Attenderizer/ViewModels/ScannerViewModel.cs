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
    public class ScannerViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;


        //public Command ScanCommand { get; set; }


        private IPageService _pageService;
        private IScannerService _scannerService;

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

            ScanCommand = new Command(OnScanCommand);
        }

        private async void OnScanCommand()
        {
            //Scan
            //Get saved QR Code
            //Compare scanned qr code and database qr code;
            //Update IsAbsent to false
            
            IsAnalyzing = false;
            IsScanning = false;
            Device.BeginInvokeOnMainThread(async () =>
            {
                
                QRCode = Result.Text;

                await _pageService.DisplayAlert("Success", "Success");
                //var codeFromDB = await _scannerService.GetCodeAsync();
            });
            //IsAnalyzing = true;
            //IsScanning = true;






            //var codeFromDB = await _scannerService.GetCodeAsync();
            //if (codeFromDB.QRCode != null)
            //{
            //    if (codeFromDB.QRCode == QRCode)
            //    {
            //        await _pageService.PushModalAsync(new SuccessPage());

            //    }
            //    else
            //    {
            //        await _pageService.PushModalAsync(new FailPage());
            //    }
            //}













        }

        private void ScanningViewModel_PropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            
        }

        //private void Scan()
        //{
        //    Device.BeginInvokeOnMainThread(async () =>
        //    {
        //        QRCode = Result.Text;

        //        //await _pageService.DisplayAlert("Scanned Item", $"Scanned code: {QRCode}" );
        //    });
        //}


        //private async void CompareQRCode(string value)//Main method
        //{
            
            
            
        //    try
        //    {
        //        string result = await GetSavedQRCode();
        //        if (result == value)
        //        {
        //            await _pageService.PushModalAsync(new SuccessPage());

        //        }
        //        else
        //        {
        //            await _pageService.PushModalAsync(new FailPage());
        //        }
        //    }
        //    catch (Exception )
        //    {

        //        throw;
        //    }
        //}

        //private async Task<string> GetSavedQRCode()// talk to API
        //{
        //    string code;
        //    var codeFromDB = await _scannerService.GetCodeAsync();
        //    if (codeFromDB.QRCode == null)
        //    {
        //        code = string.Empty;
        //    }
        //    else
        //    {
        //        code = codeFromDB.QRCode;
        //    }
        //    return code;
        //}

        private async Task<bool> UpdateAttendance(int user, LoginModel login)// talk to API
        {
            return await _scannerService.UpdateAttendanceAsync(user, login);
        }














        //Saved Code below incase i mess up tht TOP

        ////public Command ScanCommand { get; set; }


        //private IPageService _pageService;
        //private IScannerService _scannerService;

        //private string qrcode = string.Empty;
        //public string QRCode
        //{
        //    get { return qrcode; }
        //    set { qrcode = value; }
        //}


        //public ICommand ScanCommand { get; set; }
        //public string Code { get; set; }

        //public ScannerViewModel()
        //{
        //    _scannerService = new ScannerService();
        //    _pageService = new PageService();
        //    ScanCommand = new Command(OnScanResultCommand);
        //}

        //private void OnScanResultCommand()
        //{
        //    CheckQRCode(Code);
        //}




        //private async void CheckQRCode(string value)//Main method
        //{
        //    string result = await GetSavedQRCode();
        //    if (string.IsNullOrEmpty(result))
        //    {

        //        await _pageService.DisplayAlert($"Uh Oh!", "User cannot be found. Please make sure you entered your details correctly");
        //    }
        //    else if (result == value)
        //    {
        //        await _pageService.PushModalAsync(new SuccessPage());
        //        //CALL UPDATE METHOD
        //    }
        //    else
        //    {
        //        await _pageService.PushModalAsync(new FailPage());
        //    }
        //}

        //private async Task<string> GetSavedQRCode()// talk to API
        //{
        //    string code;
        //    var codeFromDB = await _scannerService.GetCodeAsync();
        //    if (codeFromDB.QRCode == null)
        //    {
        //        code = string.Empty;
        //    }
        //    else
        //    {
        //        code = codeFromDB.QRCode;
        //    }
        //    return code;
        //}

        ////private async Task<bool> UpdateAttendance(int user, LoginModel login)// talk to API
        ////{
        ////    return await _scannerService.UpdateAttendanceAsync(user, login);
        ////}
    }
}
