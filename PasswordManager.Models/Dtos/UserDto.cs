using System;
namespace PasswordManager.Models.Dtos
{
    public class UserDto
    {
        /// <summary>
        /// int Id of the User
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// string User's Name
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// string Username in most cases the Email of the user
        /// </summary>
        public string Username { get; set; }

        /// <summary>
        /// string Url of the picture profile for the user
        /// </summary>
        public string Image { get; set; }

        /// <summary>
        /// Default UserDto constructor
        /// </summary>
        public UserDto()
        {
        }
    }
}

