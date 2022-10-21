using System;
using Microsoft.AspNetCore.Components;
using PasswordManager.Models.Dtos;
using PasswordManager.Web.Services;
using PasswordManager.Web.Services.Contracts;

namespace PasswordManager.Web.Pages
{
    public class UserBase: ComponentBase
    {
        [Inject]
        public ICardService CardService { get; set; }

        [Parameter]
        public int Id { get; set; }

        public bool ShowCreateCardModal { get; set; }

        public string SearchField { get; set; } = "";

        public CardDto NewCard { get; set; } = new CardDto();

        public List<CardDto> Cards { get; set; } = new List<CardDto>();

        public List<CardDto> FilteredCards { get; set; } = new List<CardDto>();


        protected override async Task OnInitializedAsync()
        {
            Cards = await CardService.GetCards(Id);
        }

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

        private List<CardDto> searchCards()
        {
            return this.FilteredCards = Cards.FindAll(card => card.ServiceName.Contains(SearchField));
        }

        protected async Task UpdateShowCreateCardModal()
        {
            this.ShowCreateCardModal = !this.ShowCreateCardModal;
        }

        protected void UpdateSearchField(string value, string label)
        {
            this.SearchField = value;
            searchCards();

            StateHasChanged();
        }
    }
}
