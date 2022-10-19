using System;
using PasswordManager.Models.Dtos;

namespace PasswordManager.Web.Services.Contracts
{
    public interface ICardService
    {
        Task<List<CardDto>> GetCards(int Id);

        Task<PasswordDto> DeleteCard(int passwordId);

        Task<CardDto> UpdateCard(CardDto newCard);

        Task<CardDto> CreateCard(CardDto newCard);
    }
}

