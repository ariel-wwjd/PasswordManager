using System;
using PasswordManager.Api.Data;
using PasswordManager.Api.Entities;
using PasswordManager.Api.Repositories.Contracts;
using PasswordManager.Models.Dtos;

namespace PasswordManager.Api.Repositories
{
    /// <summary>
    /// Card Repository to interact with the Cards
    /// </summary>
    public class CardRepository:ICardRepository
    {
        /// <summary>
        /// Constructor that initializes the Data in Memory and Load some data on it for testing purposes
        /// </summary>
        public CardRepository()
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
                            Image = "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcQ3gL-Usq4HDkm2WsNl--ALp-mg3A01nkl24uhqgZiaDJN6Tf7NiPkAOkBddMCqXfJRDg&usqp=CAU",
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
        /// Create a new card base on the CardDto provided
        /// </summary>
        /// <param name="newCard">CardDto containing the data for the new card</param>
        /// <returns>A Password object related to the new created card</returns>
        public Password AddCard(CardDto newCard)
        {
            using (var context = new PasswordManagerDbContext())
            {
                var newPassword = new Password
                {
                    Name = newCard.ServiceName,
                    FolderId = newCard.FolderId,
                    Image = newCard.Image,
                    Url = newCard.Url,
                    Pass = newCard.Password,
                };

                var addedPassword = context.Passwords.Add(newPassword);
                context.SaveChanges();

                return addedPassword.Entity;
            }
        }

        /// <summary>
        /// Delete a Card related to the PasswordId provided
        /// </summary>
        /// <param name="PasswordId">The PasswordId of the card to be deleted</param>
        /// <returns>A Password ojject related of the deleted Card</returns>
        public Password DeleteCard(int PasswordId)
        {
            using (var context = new PasswordManagerDbContext())
            {
                var deletedPassword = context.Passwords.Remove(new Password() { Id = PasswordId });
                context.SaveChanges();

                return deletedPassword.Entity;
            }
        }

        /// <summary>
        /// Find all the cards related to a given userId
        /// </summary>
        /// <param name="userId">the user id currently logged in</param>
        /// <returns>A List of Cards belonging the given userId</returns>
        public List<Card> GetCards(int userId)
        {
            using (var context = new PasswordManagerDbContext())
            {

                return (from user in context.Users
                        where user.Id == userId
                        join folder in context.Folders
                        on user.Id equals folder.UserId
                        join password in context.Passwords
                        on folder.Id equals password.FolderId
                        select new Card
                        {
                            UserId = userId,
                            FolderId = folder.Id,
                            PasswordId = password.Id,
                            Username = user.Username,
                            FolderName = folder.Name,
                            ServiceName = password.Name,
                            Url = password.Url,
                            Image = password.Image,
                            Password = password.Pass,
                        }).ToList();
            }
        }

        /// <summary>
        /// Updates a card with a Given cardDto.
        /// </summary>
        /// <param name="newCard">Contains the data to be updated</param>
        /// <returns>A Password object related to the updated Card or an exception</returns>
        /// <exception cref="System.Exception">When the card to be updated is not found</exception>
        public Password UpdateCard(CardDto newCard)
        {
            using (var context = new PasswordManagerDbContext())
            {
                var password = context.Passwords.Find(newCard.PasswordId);

                if (password != null)
                {
                    password.Url = newCard.Url;
                    password.Name = newCard.ServiceName;
                    password.Pass = newCard.Password;
                    password.Image = newCard.Image;

                    password.FolderId = newCard.FolderId;

                    context.SaveChanges();

                    return password;
                }

                throw new Exception("Card not found");
            }
        }
    }
}
