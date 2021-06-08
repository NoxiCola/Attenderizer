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
        //List<RoleModel> _roleList = new List<RoleModel>();
        List<RoleModel> _roleList;
        List<LoginModel> _userList;
        //RoleModel newmodel = new RoleModel();
        public RoleService()
        {
            _roleList = new List<RoleModel>();
            client = new HttpClient
            {
                BaseAddress = new Uri(BaseUrl)
            };
        }

        public async Task<List<RoleModel>> GetRoleAsync()
        {
            _userList = null;
            _roleList.Clear();
            var image = string.Empty;

            response = await client.GetAsync($"api/login");
            if (response.IsSuccessStatusCode)
            {
                var content = response.Content.ReadAsStringAsync().Result;
                _userList = JsonConvert.DeserializeObject<List<LoginModel>>(content);//getting all users in login model format

                foreach (var item in _userList)
                {
                    image = item.IsAbsent ? "absent.png" : "present.png";//ternary operator (1 line if statement with )

                    _roleList.Add(new RoleModel() 
                    { 
                        FullName = item.FirstName + " " + item.LastName,
                        StudentID = item.Username.ToString(),
                        Image = image
                    });
                }

                return _roleList;
            }

            _roleList = null;
            return _roleList;
        }
    }
}
