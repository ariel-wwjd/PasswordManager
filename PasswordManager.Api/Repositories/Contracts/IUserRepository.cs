using System;
using PasswordManager.Api.Entities;
using PasswordManager.Models.Dtos;

namespace PasswordManager.Api.Repositories.Contracts
{
    /// <summary>
    /// Interface to shape the behaviour of any User Repository.
    /// </summary>
    public interface IUserRepository
    {
        /// <summary>
        /// Method to sign in whit a given user. 
        /// </summary>
        public User SignInUser(SignInUserDto signInUserDto);
    }
}
