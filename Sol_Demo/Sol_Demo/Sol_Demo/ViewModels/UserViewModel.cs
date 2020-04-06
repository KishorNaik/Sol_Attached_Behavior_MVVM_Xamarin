using Sol_Demo.Helpers.Commands;
using Sol_Demo.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Sol_Demo.ViewModels
{
    public class UserViewModel : ViewModelBase
    {
        public UserViewModel()
        {
            Users = new UserModel();
            
            UsersUi = new UserUiModel();

            Submit = new AsyncCommand(DisplayAlertBox);
        }

        private UserModel _users = null;
        public UserModel Users
        {
            get => _users;
            set => SetProperty(ref _users, value);
        }

        private UserUiModel _usersUi = null;
        public UserUiModel UsersUi
        {
            get => _usersUi;
            set => SetProperty(ref _usersUi, value);
        }

        
       
        public AsyncCommand Submit { get; set; }

            

       
        private Task DisplayAlertBox()
        {
            return Task.Run(() => {

         
                UsersUi.IsAlertBoxDisplay = true;
          
           
            });
        }

    }
}
