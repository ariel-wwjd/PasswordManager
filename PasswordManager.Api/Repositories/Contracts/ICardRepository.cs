using System;
using PasswordManager.Api.Entities;
using PasswordManager.Models.Dtos;

namespace PasswordManager.Api.Repositories.Contracts
{
    /// <summary>
    /// Interface to shape the behaviour of any Card Repository.
    /// </summary>
    public interface ICardRepository
    {
        /// <summary>
        /// Gets All card related to a given userId.
        /// </summary>
        public List<Card> GetCards(int userId);

        /// <summary>
        /// Creates a new card with the data from the CardDto object.
        /// </summary>
        public Password AddCard(CardDto newCard);

        /// <summary>
        /// Deletes a card related to a given PasswordId.
        /// </summary>
        public Password DeleteCard(int PasswordId);

        /// <summary>
        /// Update a card with the data from the CardDto object.
        /// </summary>
        public Password UpdateCard(CardDto newCard);
    }
}
