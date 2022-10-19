using System;
using Microsoft.AspNetCore.Components;
using PasswordManager.Models.Dtos;
using PasswordManager.Web.Services.Contracts;

namespace PasswordManager.Web.Pages
{
    public class SignInBase:ComponentBase
    {
        [Inject]
        public IUserService UserService { get; set; }

        [Inject]
        public NavigationManager UriHelper { get; set; }

        public UserDto CurrentUser { get; set; }

        public string username { get; set; } = "";

        public string password { get; set; } = "";

        public string error { get; set; } = "";
        

        public async Task<UserDto> SignIn(string username, string password)
        {
            try
            {
                CurrentUser = await UserService.SignInUser(new SignInUserDto { UserName = username, Password = password });

                UriHelper.NavigateTo($"User/{CurrentUser.Id}");
                return CurrentUser;
            }
            catch (Exception ex)
            {
                this.error = ex.Message;
                return default(UserDto);
            }
        }

        protected void UpdateValues(string value, string label)
        {
            switch (label)
            {
                case "Username":
                    this.username = value;
                    break;
                case "Password":
                    this.password = value;
                    break;
                default:
                    break;
            }
        }
    }
}

