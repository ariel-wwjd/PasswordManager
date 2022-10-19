using System;
using PasswordManager.Api.Entities;
using PasswordManager.Models.Dtos;

namespace PasswordManager.Api.Repositories.Contracts
{
    /// <summary>
    /// Interface to shape the behaviour of any Card Repository
    /// </summary>
    public interface ICardRepository
    {
        /// <summary>
        /// Method to get All card related to a given userId
        /// </summary>
        public List<Card> GetCards(int userId);

        /// <summary>
        /// Method to create a new card
        /// </summary>
        public Password AddCard(CardDto newCard);

        /// <summary>
        /// Method for delete a card related to a given PasswordId
        /// </summary>
        public Password DeleteCard(int PasswordId);

        /// <summary>
        /// Method to update a given card
        /// </summary>
        public Password UpdateCard(CardDto newCard);
    }
}
