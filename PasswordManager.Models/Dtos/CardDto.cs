using System;
namespace PasswordManager.Models.Dtos
{
    public class CardDto
    {
        public int UserId { get; set; }
        public int FolderId { get; set; }
        public int PasswordId { get; set; }
        public string Username { get; set; }
        public string FolderName { get; set; }
        public string ServiceName { get; set; }
        public string Url { get; set; }
        public string Image { get; set; }
        public string Password { get; set; }

        public CardDto()
        {
        }
    }
}

