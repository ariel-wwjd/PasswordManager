using System;
namespace PasswordManager.Models.Dtos
{
    public class SignInUserDto
    {
        /// <summary>
        /// string Username for sign in purposes
        /// </summary>
        public string UserName { get; set; }

        /// <summary>
        /// string Password for sign on purposes
        /// </summary>
        public string Password { get; set; }

        /// <summary>
        /// Default SignInUserDto constructor
        /// </summary>
        public SignInUserDto()
        {
        }
    }
}

