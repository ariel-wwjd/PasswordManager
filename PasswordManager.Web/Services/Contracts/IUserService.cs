using System;
using PasswordManager.Models.Dtos;

namespace PasswordManager.Web.Services.Contracts
{
    public interface IUserService
    {
        Task<UserDto> SignInUser(SignInUserDto signInUserDto);
    }
}
