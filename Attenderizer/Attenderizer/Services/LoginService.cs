using Attenderizer.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Attenderizer.Services
{
    class LoginService : ILoginService
    {
        private string BaseUrl = "https://attenderizerapi.azurewebsites.net/";
        HttpClient client;
        HttpResponseMessage response;
        LoginModel _login;
        List<LoginModel> _loginList;

        public LoginService()
        {
            client = new HttpClient
            {
                BaseAddress = new Uri(BaseUrl)
            };
        }

        public async Task<LoginModel> GetUserAsync(int url)
        {
            _login = null;
            response = await client.GetAsync($"api/login/{url}");
            if (response.IsSuccessStatusCode)
            {
                var content = response.Content.ReadAsStringAsync().Result;
                _login = JsonConvert.DeserializeObject<LoginModel>(content);

                return _login;
            }

            return _login;
        }

        public async Task<List<LoginModel>> GetListAsync()
        {
            _loginList = null;
            response = await client.GetAsync($"api/login");
            if (response.IsSuccessStatusCode)
            {
                var content = response.Content.ReadAsStringAsync().Result;
                _loginList = JsonConvert.DeserializeObject<List<LoginModel>>(content);

                return _loginList;
            }

            return _loginList;
        }
    }
}
