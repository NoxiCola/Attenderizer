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
        List<RoleModel> _roleList;
        List<LoginModel> _userList;
        RoleModel newmodel = new RoleModel();
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
            //_roleList = null;

            response = await client.GetAsync($"api/login");
            if (response.IsSuccessStatusCode)
            {
                var content = response.Content.ReadAsStringAsync().Result;
                _userList = JsonConvert.DeserializeObject<List<LoginModel>>(content);//getting all users in login model format

                foreach (var item in _userList)
                {
                    if (item.IsAbsent)
                    {
                        _roleList.Add(new RoleModel() { FullName = item.FirstName});
                    }
                }

                return _roleList;
            }

            return _roleList;
        }

        //UPDATE SERVICE
        //BACKUP JUST INCASE

        //public async Task<List<LoginModel>> GetRoleAsync()
        //{
        //    _roleList = null;
        //    //_loginList = null;

        //    response = await client.GetAsync($"api/login");
        //    if (response.IsSuccessStatusCode)
        //    {
        //        var content = response.Content.ReadAsStringAsync().Result;
        //        _roleList = JsonConvert.DeserializeObject<List<LoginModel>>(content);


        //        return _roleList;
        //    }

        //    return _roleList;
        //}
    }
}
