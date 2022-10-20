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

        public string Username { get; set; } = "";

        public string Password { get; set; } = "";

        public string Error { get; set; } = "";

        public bool IsRequiredDataMissing { get; set; }

        public SignInBase()
        {
            this.validateData();
        }
        

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
                this.Error = ex.Message;
                return default(UserDto);
            }
        }

        protected void UpdateValues(string value, string label)
        {
            switch (label)
            {
                case "Username":
                    this.Username = value;
                    break;
                case "Password":
                    this.Password = value;
                    break;
                default:
                    break;
            }

            this.validateData();
            StateHasChanged();
        }

        private void validateData()
        {
            Console.WriteLine(IsRequiredDataMissing);
            if (this.Username != "" && this.Password != "")
            {
                this.IsRequiredDataMissing = false;
            }
            else
            {
                this.IsRequiredDataMissing = true;
            }
        }
    }
}

