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
        LoginModel login;

        public LoginService()
        {
            client = new HttpClient
            {
                BaseAddress = new Uri(BaseUrl)
            };
        }

        public async Task<LoginModel> GetUserAsync(int url)
        {
            login = null;
            response = await client.GetAsync($"api/login/{url}");
            if (response.IsSuccessStatusCode)
            {
                var content = response.Content.ReadAsStringAsync().Result;
                login = JsonConvert.DeserializeObject<LoginModel>(content);

                return login;
            }

            return login;
        }
    }
}
