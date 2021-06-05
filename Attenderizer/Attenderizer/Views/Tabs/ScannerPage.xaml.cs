﻿using Attenderizer.Models;
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
        private ScannerViewModel _scannerViewModel = new ScannerViewModel();

        LoginModel _loginModel = new LoginModel();

        public ScannerPage()
        {
            InitializeComponent();
            BindingContext = new ScannerViewModel();

            _scannerService = new ScannerService();
            _pageService = new PageService();
        }

        private async void Handle_OnScanResult(ZXing.Result result)
        {
            Device.BeginInvokeOnMainThread(async () =>
            {
                _scanView.IsAnalyzing = false;
                await _scannerViewModel.OnQRScan(result.Text);//send data to ScannerViewModel class
            });
        }

        protected override void OnAppearing()
        {
            _scanView.IsAnalyzing = true;
        }

    }
}