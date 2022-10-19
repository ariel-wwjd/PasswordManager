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

        public CardDto Data { get; set; } = new CardDto();

        public Boolean ShowCreateCardModal { get; set; }

        public List<CardDto> Cards { get; set; } = new List<CardDto>();


        protected override async Task OnInitializedAsync()
        {
            Cards = await CardService.GetCards(Id);
        }

        public IEnumerable<IGrouping<int, CardDto>> SplitList()
        {
            return Cards.GroupBy(card => card.FolderId);
        }

        protected async Task UpdateShowCreateCardModal()
        {
            this.ShowCreateCardModal = !this.ShowCreateCardModal;
        }
    }
}
