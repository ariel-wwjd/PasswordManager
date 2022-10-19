using System;
using Microsoft.AspNetCore.Components;
using PasswordManager.Models.Dtos;
using PasswordManager.Web.Services.Contracts;

namespace PasswordManager.Web.Pages
{
    public class CardBase:ComponentBase
    {
        [Inject]
        public IClipboardService ClipboardService { get; set; }

        [Inject]
        public ICardService CardService { get; set; }

        [Inject]
        public NavigationManager UriHelper { get; set; }

        [Parameter]
        public CardDto Data { get; set; }

        public Boolean ShowPassword { get; set; }

        public Boolean ShowEditCardModal { get; set; }


        protected async Task UpdateShowPassword()
        {
            this.ShowPassword = !ShowPassword;
        }

        protected async Task CopyToClipboard()
        {
            await ClipboardService.CopyToClipboard(Data.Password);

            await UpdateShowPassword();
        }

        protected async Task DeleteCard(int id)
        {
            try
            {
                await CardService.DeleteCard(id);
                this.UriHelper.NavigateTo(UriHelper.Uri, forceLoad: true);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        protected async Task UpdateShowEditCardModal()
        {
            this.ShowEditCardModal = !this.ShowEditCardModal;
        }
    }
}
