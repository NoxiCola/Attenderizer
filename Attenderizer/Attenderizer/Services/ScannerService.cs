using Attenderizer.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace Attenderizer.Services
{
    class ScannerService : IScannerService
    {
        private string BaseUrl = "https://attenderizerapi.azurewebsites.net/";
        HttpClient client;
        HttpResponseMessage response;
        ScannerModel qrCode;
        IPageService _pageService = new PageService();
        LoginModel _loginModel = new LoginModel();

        public ScannerService()
        {
            client = new HttpClient
            {
                BaseAddress = new Uri(BaseUrl)
            };
        }

        public async Task<ScannerModel> GetCodeAsync()
        {
            qrCode = null;
            response = await client.GetAsync($"api/qrcode");
            if (response.IsSuccessStatusCode)
            {
                var content = response.Content.ReadAsStringAsync().Result;
                qrCode = JsonConvert.DeserializeObject<ScannerModel>(content);

                return qrCode;
            }

            return qrCode;
        }

        public async Task<bool> UpdateAttendanceAsync(int userName, LoginModel model)
        {
            var json = JsonConvert.SerializeObject(model);
            HttpContent content = new StringContent(json);

            content.Headers.ContentType = new MediaTypeHeaderValue("application/json");

            response = await client.PutAsync($"api/login/{userName}", content);

            if (response.IsSuccessStatusCode)
                return true;
            else
                return false;
        }


    }
}
