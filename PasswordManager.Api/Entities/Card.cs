using System;
namespace PasswordManager.Api.Entities
{
    public class Card
    {
        /// <summary>
        /// Int Id related to the owner user of the card 
        /// </summary>
        public int UserId { get; set; }

        /// <summary>
        /// Int Id related to the folder that contains the card 
        /// </summary>
        public int FolderId { get; set; }

        /// <summary>
        /// Int Id for the new password
        /// </summary>
        public int PasswordId { get; set; }

        /// <summary>
        /// string Email for the current user
        /// </summary>
        public string Username { get; set; }

        /// <summary>
        /// string Name for the colder where the password belongs
        /// </summary>
        public string FolderName { get; set; }

        /// <summary>
        /// string Name of the service where the password belongs
        /// </summary>
        public string ServiceName { get; set; }

        /// <summary>
        /// string URL where the passwords belongs
        /// </summary>
        public string Url { get; set; }

        /// <summary>
        /// string of the url where the image related to the password is hosted
        /// </summary>
        public string Image { get; set; }

        /// <summary>
        /// string Password
        /// </summary>
        public string Password { get; set; }

        /// <summary>
        /// default Card Constructor
        /// </summary>
        public Card()
        {
        }
    }
}

