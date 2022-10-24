using System;
using PasswordManager.Models.Dtos;

namespace PasswordManager.Web.Services.Contracts
{
    /// <summary>
    /// Interface to shape the Card Service behaviour.
    /// </summary>
    public interface ICardService
    {
        /// <summary>
        /// Gets All cards related to a given userId.
        /// </summary>
        Task<List<CardDto>> GetCards(int Id);

        /// <summary>
        /// Deletes a card related to a given PasswordId.
        /// </summary>
        Task<PasswordDto> DeleteCard(int passwordId);

        /// <summary>
        /// Updates a given card base on the CardDto provided.
        /// </summary>
        Task<CardDto> UpdateCard(CardDto newCard);

        /// <summary>
        /// Create a new card using de data provided in the CardDto.
        /// </summary>
        Task<CardDto> CreateCard(CardDto newCard);
    }
}
