using System;
namespace PasswordManager.Models.Dtos
{
    public class UserDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Username { get; set; }
        public string Image { get; set; }

        public UserDto()
        {
        }
    }
}

