using System;
using PasswordManager.Api.Entities;
using PasswordManager.Models.Dtos;

namespace PasswordManager.Api.Extensions
{
    /// <summary>
    /// Static Class to help a convertion for Dtos
    /// </summary>
    public static class DtoConversions
    {
        /// <summary>
        /// Static method for helps converting a User into aUserDto
        /// </summary>
        /// <param name="users">The user in User Type</param>
        /// <returns>An IEnumerable containing the user trasfored to UserDto</returns>
        public static IEnumerable<UserDto> convertToUserDtos(this IEnumerable<User> users)
        {
            return (from user in users
                    select new UserDto
                    {
                        Id = user.Id,
                        Name = user.Name,
                        Username = user.Username,
                        Image = user.Image,
                    }).ToList();
        }
    }
}

