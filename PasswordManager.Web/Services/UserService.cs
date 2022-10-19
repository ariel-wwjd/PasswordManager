using System;
using System.Net.Http.Json;
using PasswordManager.Models.Dtos;
using PasswordManager.Web.Services.Contracts;

namespace PasswordManager.Web.Services
{
    public class UserService:IUserService
    {
        private readonly HttpClient httpClient;

        public UserService(HttpClient httpClient)
        {
            this.httpClient = httpClient;
        }

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

