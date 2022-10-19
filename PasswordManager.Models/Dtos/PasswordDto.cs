using System;
namespace PasswordManager.Models.Dtos
{
    public class PasswordDto
    {
        public int Id { get; set; }
        public int FolderId { get; set; }
        public string Pass { get; set; }
        public string Image { get; set; }
        public string Url { get; set; }
        public string Name { get; set; }

        public PasswordDto()
        {
        }
    }
}

