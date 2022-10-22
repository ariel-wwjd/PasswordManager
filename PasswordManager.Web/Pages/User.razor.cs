using System;
using Microsoft.AspNetCore.Components;
using PasswordManager.Models.Dtos;
using PasswordManager.Web.Services;
using PasswordManager.Web.Services.Contracts;

namespace PasswordManager.Web.Pages
{
    /// <summary>
    /// Class used to provide the functionality and behaviour to the Sign In Page.
    /// </summary>
    public class UserBase: ComponentBase
    {
        /// <summary>
        /// Allows the use of the Card Service to perform a CRUD operations, this service is set by dependency injection.
        /// </summary>
        [Inject]
        public ICardService CardService { get; set; }

        /// <summary>
        /// Parameter that receives the users Id used to find the users Cards.
        /// </summary>
        [Parameter]
        public int Id { get; set; }

        /// <summary>
        /// Boolena value used to set the show and hide the Create Card Modal component. 
        /// </summary>
        public bool ShowCreateCardModal { get; set; }

        /// <summary>
        /// Value belonging to the search input used to filter de cards based on the ServiceName.
        /// </summary>
        public string SearchField { get; set; } = "";

        /// <summary>
        /// Object used to hold and communicate the card data between the Client and Service.
        /// </summary>
        public CardDto NewCard { get; set; } = new CardDto();

        /// <summary>
        /// Card list on CardDto shape, to hold the Service response of the user cards.
        /// </summary>
        public List<CardDto> Cards { get; set; } = new List<CardDto>();

        /// <summary>
        /// Cards list on CardDto shape, to hold the filtered cards based on the search input.
        /// </summary>
        public List<CardDto> FilteredCards { get; set; } = new List<CardDto>();

        /// <summary>
        /// Method used to get the cards before the page gets completly render and include the cards on the final render.
        /// </summary>
        /// <returns>Void return</returns>
        protected override async Task OnInitializedAsync()
        {
            Cards = await CardService.GetCards(Id);
        }

        /// <summary>
        /// Method used to classify the cards by folder Id.
        /// </summary>
        /// <returns>List of grouped Cards</returns>
        public IEnumerable<IGrouping<int, CardDto>> SplitList()
        {
            if (SearchField == "")
            {
                return Cards.GroupBy(card => card.FolderId);
            }
            else
            {
                return FilteredCards.GroupBy(card => card.FolderId);
            }
        }

        /// <summary>
        /// Method used to filter the cards by folder Id and the search input value.
        /// </summary>
        /// <returns>List of grouped and filtered Cards</returns>
        private List<CardDto> searchCards()
        {
            return this.FilteredCards = Cards.FindAll(card => card.ServiceName.Contains(SearchField));
        }

        /// <summary>
        /// This Method is a callback used to toggles the Create Modal Form Visibility.
        /// </summary>
        /// <returns>Void return</returns>
        protected async Task UpdateShowCreateCardModal()
        {
            this.ShowCreateCardModal = !this.ShowCreateCardModal;
        }

        /// <summary>
        /// This Method is a callback used to update the value of the search input.
        /// </summary>
        protected void UpdateSearchField(string value, string label)
        {
            this.SearchField = value;
            searchCards();

            StateHasChanged();
        }
    }
}
