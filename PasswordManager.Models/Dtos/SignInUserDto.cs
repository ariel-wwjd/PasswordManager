using System;
namespace PasswordManager.Models.Dtos
{
    public class SignInUserDto
    {
        public string UserName { get; set; }
        public string Password { get; set; }

        public SignInUserDto()
        {
        }
    }
}

