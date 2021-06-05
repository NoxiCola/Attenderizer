using Attenderizer.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Attenderizer.Services
{
    class RoleService
    {
        private string BaseUrl = "https://attenderizerapi.azurewebsites.net/";
        HttpClient client;
        HttpResponseMessage response;
        LoginModel _role = new LoginModel();

        public RoleService()
        {
            client = new HttpClient
            {
                BaseAddress = new Uri(BaseUrl)
            };
        }

        public async Task<LoginModel> GetRoleAsync()
        {
            _role = null;
            response = await client.GetAsync($"api/login");
            if (response.IsSuccessStatusCode)
            {
                var content = response.Content.ReadAsStringAsync().Result;
                _role = JsonConvert.DeserializeObject<LoginModel>(content);

                return _role;
            }

            return _role;
        }
    }
}
