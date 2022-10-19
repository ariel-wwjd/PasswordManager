using System;
using Microsoft.EntityFrameworkCore;
using PasswordManager.Api.Data;
using PasswordManager.Api.Entities;
using PasswordManager.Api.Repositories.Contracts;
using PasswordManager.Models.Dtos;

namespace PasswordManager.Api.Repositories
{
    /// <summary>
    /// User Repository class with Data in Memory configuration
    /// </summary>
    public class UserRepository:IUserRepository
    {
        /// <summary>
        /// Constructor that initializes the Data in Memory and Load some data on it for testing purposes
        /// </summary>
        public UserRepository()
        {
            using (var context = new PasswordManagerDbContext())
            {
                if (context.Users.Count() == 0)
                {
                    var users = new List<User>
                    {
                        new User
                        {
                            Id = 1,
                            Name = "Benjamin",
                            Username = "benjamin@gmail.com",
                            Password = "pass-word",
                            Image = "https://www.mensjournal.com/wp-content/uploads/mf/1280-selfie.jpg?w=900&quality=86&strip=all"
                        },
                        new User
                        {
                            Id = 2,
                            Name = "Khatleen",
                            Username = "khatleen@gmail.com",
                            Password = "pass-word",
                            Image = "https://img.freepik.com/free-photo/half-profile-image-beautiful-young-woman-with-bob-hairdo-posing-gazing-with-eyes-full-reproach-suspicion-human-facial-expressions-emotions-reaction-feelings_343059-4660.jpg?w=2000"
                        }
                    };

                    context.Users.AddRange(users);
                    context.SaveChanges();

                    var folders = new List<Folder>
                    {
                        new Folder
                        {
                            Id = 1,
                            Name = "Browse",
                            UserId = 1,
                        },
                        new Folder
                        {
                            Id = 2,
                            Name = "Shopping",
                            UserId = 1,
                        },
                         new Folder
                        {
                            Id = 3,
                            Name = "SocialMedia",
                            UserId = 1,
                        },
                        new Folder
                        {
                            Id = 4,
                            Name = "Shopping",
                            UserId = 2,
                        },
                        new Folder
                        {
                            Id = 5,
                            Name = "SocialMedia",
                            UserId = 2,
                        },
                    };

                    context.Folders.AddRange(folders);
                    context.SaveChanges();

                    var passwords = new List<Password>
                    {
                        new Password
                        {
                            Id = 1,
                            FolderId = 1,
                            Name = "Google",
                            Pass = "P@ssWord#",
                            Url = "https://www.google.com",
                            Image = "https://upload.wikimedia.org/wikipedia/commons/thumb/2/2f/Google_2015_logo.svg/1200px-Google_2015_logo.svg.png",
                        },
                        new Password
                        {
                            Id = 2,
                            FolderId = 1,
                            Name = "Evernote",
                            Pass = "P@ssWord#",
                            Url = "https://evernote.com/",
                            Image = "https://toppng.com/uploads/preview/evernote-logo-vector-download-free-11574200503dypn1v2syh.png",
                        },
                        new Password
                        {
                            Id = 3,
                            FolderId = 1,
                            Name = "Workday",
                            Pass = "P@ssWord#",
                            Url = "https://www.workday.com/",
                            Image = "https://accelerationeconomy.com/wp-content/uploads/2021/06/Workday_Logo.png",
                        },
                        new Password
                        {
                            Id = 4,
                            FolderId = 2,
                            Name = "Amazon",
                            Pass = "P@ssWord#",
                            Url = "https://www.amazon.com/",
                            Image = "https://cdn2.downdetector.com/static/uploads/logo/amazon.png",
                        },
                        new Password
                        {
                            Id = 5,
                            FolderId = 2,
                            Name = "Ebay",
                            Pass = "P@ssWord#",
                            Url = "https://www.ebay.com/",
                            Image = "https://upload.wikimedia.org/wikipedia/commons/thumb/1/1b/EBay_logo.svg/640px-EBay_logo.svg.png",
                        },
                        new Password
                        {
                            Id = 6,
                            FolderId = 3,
                            Name = "Facebook",
                            Pass = "P@ssWord#",
                            Url = "https://www.facebook.com/",
                            Image = "https://www.catholiccharitiesdc.org/wp-content/uploads/2018/10/facebook.png",
                        },
                        new Password
                        {
                            Id = 7,
                            FolderId = 3,
                            Name = "Pinterest",
                            Pass = "P@ssWord#",
                            Url = "https://www.pinterest.com/",
                            Image = "https://cdn2.downdetector.com/static/uploads/logo/pinterest_logo_1.png",
                        },
                        new Password
                        {
                            Id = 8,
                            FolderId = 4,
                            Name = "Walmart",
                            Pass = "P@ssWord#",
                            Url = "https://www.walmart.com/",
                            Image = "https://cdn.corporate.walmart.com/dims4/WMT/71169a3/2147483647/strip/true/crop/2389x930+0+0/resize/980x381!/quality/90/?url=https%3A%2F%2Fcdn.corporate.walmart.com%2Fd6%2Fe7%2F48e91bac4a8ca8f22985b3682370%2Fwalmart-logos-lockupwtag-horiz-blu-rgb.png",
                        },
                    };

                    context.Passwords.AddRange(passwords);
                    context.SaveChanges();
                }
            }
        }

        /// <summary>
        /// Sign In method to verify the user credentials
        /// </summary>
        /// <returns>A current user data that belogns to the provided credentials or a null value</returns>
        public User SignInUser(SignInUserDto signInUserDto)
        {
            using (var context = new PasswordManagerDbContext())
            {
                var currentUser = context.Users
                    .Where(user => user.Username == signInUserDto.UserName && user.Password == signInUserDto.Password)
                    .Select(user => new User
                    {
                        Id = user.Id,
                        Image = user.Image,
                        Name = user.Name,
                        Password = user.Password,
                        Username = user.Username,
                    }).SingleOrDefault();

                return currentUser;

            }
        }
    }
}

