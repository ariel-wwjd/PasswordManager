using System;
using System.Net.Http.Json;
using PasswordManager.Models.Dtos;
using PasswordManager.Web.Services.Contracts;

namespace PasswordManager.Web.Services
{
    public class CardService:ICardService
    {
        private readonly HttpClient httpClient;

        public CardService(HttpClient httpClient)
        {
            this.httpClient = httpClient;
        }

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

