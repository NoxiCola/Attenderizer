using Attenderizer.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Attenderizer.Services
{
    public class RoleService : IRoleService
    {
        private string BaseUrl = "https://attenderizerapi.azurewebsites.net/";
        HttpClient client;
        HttpResponseMessage response;
        //List<RoleModel> _roleList;
        List<LoginModel> _roleList;
        public RoleService()
        {
            client = new HttpClient
            {
                BaseAddress = new Uri(BaseUrl)
            };
        }

        public async Task<List<LoginModel>> GetRoleAsync()
        {
            _roleList = null;
            //_loginList = null;

            response = await client.GetAsync($"api/login");
            if (response.IsSuccessStatusCode)
            {
                var content = response.Content.ReadAsStringAsync().Result;
                _roleList = JsonConvert.DeserializeObject<List<LoginModel>>(content);


                return _roleList;
            }

            return _roleList;
        }
    }
}
