using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Attenderizer.Models;
using Attenderizer.Services;
using MvvmHelpers;
using MvvmHelpers.Commands;

namespace Attenderizer.ViewModels
{
    public class RoleViewModel : BaseViewModel
    {
        public ObservableCollection<LoginModel> Role { get; set; }
        public ObservableCollection<RoleModel> Role2 { get; set; }
        RoleService _roleService = new RoleService();

        string image = "test.png";

        public string Image
        {
            get { return image; }
            set { image = value; }
        }

        public RoleViewModel()
        {
            //_roleService = new RoleService();
            Role = new ObservableRangeCollection<LoginModel>();
            Role2 = new ObservableRangeCollection<LoginModel>();
            GetRoleCommand = new AsyncCommand(GetRoleList);
            RefreshCommand = new AsyncCommand(Refresh);

            GetRoleCommand.Execute(null);
        }
        public ICommand GetRoleCommand { get; set; }
        public AsyncCommand RefreshCommand { get; set; }

        private async Task GetRoleList()
        {
            var userList = await _roleService.GetRoleAsync();

            foreach (var user in userList)
            {
                Role2.Add(user);
            }    
        } 

        public async Task Refresh()
        {
            IsBusy = true;
            await Task.Delay(3000);
            Role.Clear();
            await GetRoleList();
            IsBusy = false;
        }
    }

    
}
