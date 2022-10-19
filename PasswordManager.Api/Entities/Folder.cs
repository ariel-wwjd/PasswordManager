using System;
namespace PasswordManager.Api.Entities
{
    public class Folder
    {
        /// <summary>
        /// int Id for the Folder
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// int Id of the user owner of the folder
        /// </summary>
        public int UserId { get; set; }

        /// <summary>
        /// string Folder Name 
        /// </summary>
        public string? Name { get; set; }

        /// <summary>
        /// Default constructor
        /// </summary>
        public Folder()
        {
        }
    }
}

