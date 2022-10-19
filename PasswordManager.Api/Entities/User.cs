using System;
namespace PasswordManager.Api.Entities
{
    public class User
    {
        /// <summary>
        /// int Id of the User
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// string Users Name
        /// </summary>
        public string? Name { get; set; }

        /// <summary>
        /// string Username in most cases the Email of the user
        /// </summary>
        public string? Username { get; set; }

        /// <summary>
        /// string Password for login into the App
        /// </summary>
        public string? Password { get; set; }

        /// <summary>
        /// string Url of the picture profile of the user
        /// </summary>
        public string? Image { get; set; }
    }
}
