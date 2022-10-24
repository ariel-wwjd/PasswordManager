using System;
using System.Net.Http.Json;
using PasswordManager.Models.Dtos;
using PasswordManager.Web.Services.Contracts;

namespace PasswordManager.Web.Services
{
    /// <summary>
    /// Card Service Provider
    /// </summary>
    public class CardService:ICardService
    {
        /// <summary>
        /// Allows the comunication with the Server handling CRUD type requests.
        /// </summary>
        private readonly HttpClient httpClient;

        /// <summary>
        /// Contructor that initialize the httpClient.
        /// </summary>
        /// <param name="httpClient">Initialized by dependency injection</param>
        public CardService(HttpClient httpClient)
        {
            this.httpClient = httpClient;
        }

        /// <summary>
        /// Gets all cards related to a given userId
        /// </summary>
        /// <param name="userId">the user id of the user currently logged in</param>
        /// <returns>A List of Cards belonging the given userId</returns>
        /// <exception cref="System.Exception">When no content was found or the service is not available</exception>
        public async Task<List<CardDto>> GetCards(int Id)
        {
            try
            {
                var response = await this.httpClient.GetAsync($"api/card/{Id}");

                if (response.IsSuccessStatusCode)
                {
                    if (response.StatusCode == System.Net.HttpStatusCode.NoContent)
                    {
                        throw new Exception($"Http status:{response.StatusCode} Message: No Cards Found");
                    }

                    return await response.Content.ReadFromJsonAsync<List<CardDto>>();
                }
                else
                {
                    var message = await response.Content.ReadAsStringAsync();
                    throw new Exception($"Http status:{response.StatusCode} Message:{message}");
                }
            }
            catch (Exception)
            {
                throw new Exception("No Cards Found please try again later");
            }

        }

        /// <summary>
        /// Deletes a card related to a given PasswordId
        /// </summary>
        /// <param name="passwordId">The PasswordId of the card to be deleted</param>
        /// <returns>A PasswordDto object related of the deleted Card</returns>
        /// <exception cref="System.Exception">When the card was not found or the service is not available</exception>
        public async Task<PasswordDto> DeleteCard(int passwordId)
        {
            try
            {
                var response = await this.httpClient.DeleteAsync($"api/card/{passwordId}");

                if (response.IsSuccessStatusCode)
                {
                    if (response.StatusCode == System.Net.HttpStatusCode.NoContent)
                    {
                        throw new Exception($"Http status:{response.StatusCode} Message: No Cards Found");
                    }

                    return await response.Content.ReadFromJsonAsync<PasswordDto>();
                }
                else
                {
                    var message = await response.Content.ReadAsStringAsync();
                    throw new Exception($"Http status:{response.StatusCode} Message:{message}");
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"Can not delete the card, please try again later, Error: {ex.Message}");
            }
        }

        /// <summary>
        /// Updates a card with a Given cardDto.
        /// </summary>
        /// <param name="UpdatedCard">Contains the data to be updated</param>
        /// <returns>A CardDto object related to the updated Card or an exception</returns>
        /// <exception cref="System.Exception">When the card to be updated was not found or the service is not available</exception>
        public async Task<CardDto> UpdateCard(CardDto UpdatedCard)
        {
            try
            {
                var response = await this.httpClient.PutAsJsonAsync("api/card", UpdatedCard);

                if (response.IsSuccessStatusCode)
                {
                    if (response.StatusCode == System.Net.HttpStatusCode.NoContent)
                    {
                        throw new Exception($"Http status:{response.StatusCode} Message: Fail when tried to update");
                    }

                    return await response.Content.ReadFromJsonAsync<CardDto>();
                }
                else
                {
                    var message = await response.Content.ReadAsStringAsync();
                    throw new Exception($"Http status:{response.StatusCode} Message:{message}");
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"Can not update the card, please try again later, Error: {ex.Message}");
            }
        }

        /// <summary>
        /// Create a new card base on the CardDto provided
        /// </summary>
        /// <param name="newCard">CardDto containing the data for the new card</param>
        /// <returns>A CardDto object related to the new created card</returns>
        /// <exception cref="System.Exception">When the service is not able to create a card or the service is not available</exception>
        public async Task<CardDto> CreateCard(CardDto newCard)
        {
            try
            {
                var response = await this.httpClient.PostAsJsonAsync("api/card", newCard);

                if (response.IsSuccessStatusCode)
                {
                    if (response.StatusCode == System.Net.HttpStatusCode.NoContent)
                    {
                        throw new Exception($"Http status:{response.StatusCode} Message: Fail when creating a card");
                    }

                    return await response.Content.ReadFromJsonAsync<CardDto>();
                }
                else
                {
                    var message = await response.Content.ReadAsStringAsync();
                    throw new Exception($"Http status:{response.StatusCode} Message:{message}");
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"Can not create a card, please try again later, Error: {ex.Message}");
            }
        }
    }
}

