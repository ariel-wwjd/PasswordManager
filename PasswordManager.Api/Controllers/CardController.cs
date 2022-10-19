using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using PasswordManager.Api.Repositories.Contracts;
using PasswordManager.Models.Dtos;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace PasswordManager.Api.Controllers
{
    /// <summary>
    /// API Controller class for Cards actions
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class CardController : ControllerBase
    {
        /// <summary>
        /// The repository provider for the Cards 
        /// </summary>
        /// <value>is a ICardRepository</value>
        private readonly ICardRepository cardRepository;

        /// <summary>
        /// Card Controller Constructor
        /// </summary>
        /// <param name="cardRepository">Receive the cardRepository by dependency injection</param>
        public CardController(ICardRepository cardRepository)
        {
            this.cardRepository = cardRepository;
        }

        /// <summary>
        /// GET method to find all the available Cards for a guiven userId.
        /// </summary>
        /// <param name="id">The userId to find the related cards</param>
        /// <returns>An OK with an IEnumerable response with the cards related to the provided Id or an Exception</returns>
        /// <exception cref="System.Exception">when Server is not available or an internal error happen</exception>
        [HttpGet("{id}")]
        public ActionResult<IEnumerable<CardDto>> GetCards(int id)
        {
            try
            {
                var cards = Ok(cardRepository.GetCards(id));
                return cards;
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        /// <summary>
        /// POST method to create a new card.
        /// </summary>
        /// <param name="newCard">CardDto containing the data for the new card</param>
        /// <returns>OK Response containing a PaswordDto when the card is correctly added or an Exception</returns>
        /// <exception cref="System.Exception">when Server is not available or an internal error happen</exception>
        [HttpPost]
        public ActionResult<PasswordDto> AddCard(CardDto newCard)
        {
            try
            {
                var newPass = cardRepository.AddCard(newCard);
                return Ok(newPass);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        /// <summary>
        /// DELETE method to delete a card related to the given PasswordId.
        /// </summary>
        /// <param name="passwordId">The Id of the password related to the card to be deleted</param>
        /// <returns>An OK Response containing a PasswordDto deleted or an Exception</returns>
        /// <exception cref="System.Exception">when Server is not available or an internal error happen</exception>
        [HttpDelete("{passwordId}")]
        public ActionResult<PasswordDto> DeleteCard(int passwordId)
        {
            try
            {
                var deletedPassword = cardRepository.DeleteCard(passwordId);
                return Ok(deletedPassword);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        /// <summary>
        /// PUT method to update a given card.
        /// </summary>
        /// <param name="newCard">CardDto containing the data to update</param>
        /// <returns>An OK response with the PasswordDto related to the updated Card</returns>
        /// <exception cref="System.Exception">when Server is not available or an internal error happen</exception>
        [HttpPut]
        public ActionResult<PasswordDto> UpdateCard(CardDto newCard)
        {
            try
            {
                var updatedCard = cardRepository.UpdateCard(newCard);
                return Ok(updatedCard);

            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }
    }
}

