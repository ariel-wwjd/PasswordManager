using System;
using Microsoft.AspNetCore.Components;
using PasswordManager.Models.Dtos;
using PasswordManager.Web.Services.Contracts;

namespace PasswordManager.Web.Pages
{
    /// <summary>
    /// Class used to provide the functionality and behaviour to the Sign In Page.
    /// </summary>
    public class SignInBase:ComponentBase
    {
        /// <summary>
        /// Allows the use of the User service to perform CRUD operations, this service is set by dependency injection.
        /// </summary>
        [Inject]
        public IUserService UserService { get; set; }

        /// <summary>
        /// Allows the App navigation, this service is set by dependency injection.
        /// </summary>
        [Inject]
        public NavigationManager UriHelper { get; set; }

        /// <summary>
        /// Holds the data for the current user in a shape of the UserDto object.
        /// </summary>
        public UserDto CurrentUser { get; set; }

        /// <summary>
        /// Holds the value of the Username for sign in purposes.
        /// </summary>
        public string Username { get; set; } = "";

        /// <summary>
        /// Holds the value of the Password for sign in purposes.
        /// </summary>
        public string Password { get; set; } = "";

        /// <summary>
        /// Holds a message when a error happens on the sign in process.
        /// </summary>
        public string Error { get; set; } = "";

        /// <summary>
        /// Boolean value used to validate that all the inputs hold the correct data.
        /// </summary>
        public bool IsRequiredDataMissing { get; set; }

        /// <summary>
        /// Contructor that initialize the data validation of the sign in form.
        /// </summary>
        public SignInBase()
        {
            this.validateData();
        }

        /// <summary>
        /// This Method is used to sign in a user.
        /// </summary>
        /// <param name="username">The users username credential to sign in</param>
        /// <param name="password">The users password credential to sign in</param>
        /// <returns>A UserDto when a user exists or an exception</returns>
        /// <exception cref="System.Exception">When a service is not able to process the request</exception>
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

        /// <Summary>
        /// Funtion used to handle the change on the sign in form.
        /// </Summary>
        /// <param name="label">The input label asigned on every input of the form</param>
        /// <param name="value">The new value typed on the input</param>
        /// <returns>Void return</returns>
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

        /// <Summary>
        /// Function used to validate that all the required fields holds a valid data.
        /// </Summary>
        /// <returns>Void return</returns>
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

