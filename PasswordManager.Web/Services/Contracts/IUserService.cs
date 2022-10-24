using System;
using PasswordManager.Models.Dtos;

namespace PasswordManager.Web.Services.Contracts
{
    /// <summary>
    /// Interface to shape the User Repository behaviour.
    /// </summary>
    public interface IUserService
    {
        /// <summary>
        /// Tries to Sign In whit a given user. 
        /// </summary>
        Task<UserDto> SignInUser(SignInUserDto signInUserDto);
    }
}
