using System;
using System.Net.Http.Json;
using PasswordManager.Models.Dtos;
using PasswordManager.Web.Services.Contracts;

namespace PasswordManager.Web.Services
{
    /// <summary>
    /// User Service Povider.
    /// </summary>
    public class UserService:IUserService
    {
        /// <summary>
        /// Allows the comunication with the Server handling CRUD type requests.
        /// </summary>
        private readonly HttpClient httpClient;

        /// <summary>
        /// Contructor that initialize the httpClient.
        /// </summary>
        /// <param name="httpClient">Initialized by dependency injection</param>
        public UserService(HttpClient httpClient)
        {
            this.httpClient = httpClient;
        }

        /// <summary>
        /// Tries to Sign In a user with the credentials provided
        /// </summary>
        /// <param name="signInUserDto">The user credentials</param>
        /// <returns>A UserDto when the credentials are correct</returns>
        /// <exception cref="System.Exception">When no user was found or the service is not available</exception>
        public async Task<UserDto> SignInUser(SignInUserDto signInUserDto)
        {
            try
            {
                var response = await this.httpClient.PostAsJsonAsync<SignInUserDto>("api/users", signInUserDto);
                if (response.IsSuccessStatusCode)
                {
                    if (response.StatusCode == System.Net.HttpStatusCode.NoContent)
                    {
                        throw new Exception($"Http status:{response.StatusCode} Message: No User Found");
                    }

                    return await response.Content.ReadFromJsonAsync<UserDto>();
                }
                else
                {
                    var message = await response.Content.ReadAsStringAsync();
                    throw new Exception($"Http status:{response.StatusCode} Message:{message}");
                }
            }
            catch (Exception)
            {
                throw new Exception("User Not Found please make sure the Username and Password are correct and try again");
            }
        }
    }
}

