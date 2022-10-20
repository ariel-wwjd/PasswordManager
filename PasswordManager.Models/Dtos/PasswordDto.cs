using System;
namespace PasswordManager.Models.Dtos
{
    public class PasswordDto
    {
        /// <summary>
        /// int Id for the Password
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// int Id of the Folder where the password belongs 
        /// </summary>
        public int FolderId { get; set; }

        /// <summary>
        /// string Password
        /// </summary>
        public string Pass { get; set; }

        /// <summary>
        /// string Image Url for the service or web page where the password belongs 
        /// </summary>
        public string Image { get; set; }

        /// <summary>
        /// string Url of the service where the password belongs
        /// </summary>
        public string Url { get; set; }

        /// <summary>
        /// string Name of the service where the password belongs
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Default PasswordDto constructor
        /// </summary>
        public PasswordDto()
        {
        }
    }
}

