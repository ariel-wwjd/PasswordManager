using System;
using Microsoft.AspNetCore.Components;
using PasswordManager.Models.Dtos;
using PasswordManager.Web.Services.Contracts;

namespace PasswordManager.Web.Pages
{
    /// <summary>
    /// Class used to provide the functionality and behaviour to the Card compomnent
    /// </summary>
    public class CardBase:ComponentBase
    {
        /// <summary>
        /// Allows the use of the clipboard, this service is set by dependency injection.
        /// </summary>
        [Inject]
        public IClipboardService ClipboardService { get; set; }

        /// <summary>
        /// Allows the use of the Card Service to perform a CRUD operations, this service is set by dependency injection.
        /// </summary>
        [Inject]
        public ICardService CardService { get; set; }

        /// <summary>
        /// Allows the App navigation, this service is set by dependency injection.
        /// </summary>
        [Inject]
        public NavigationManager UriHelper { get; set; }

        /// <summary>
        /// Parameter object used to hold communicate the card data between the Client and Service.
        /// </summary>
        [Parameter]
        public CardDto Data { get; set; }

        /// <summary>
        /// Boolean value used to show and hide the password.
        /// </summary>
        public bool ShowPassword { get; set; }

        /// <summary>
        /// Boolena value used to set the show and hide the Edit Modal component. 
        /// </summary>
        public bool ShowEditCardModal { get; set; }

        /// <summary>
        /// This Method is a callback used to toggles the password visibility.
        /// </summary>
        protected async Task UpdateShowPassword()
        {
            this.ShowPassword = !ShowPassword;
        }

        /// <summary>
        /// This Method is a callback used to toggles the Edit Modal Form Visibility.
        /// </summary>
        /// <returns>Void return</returns>
        protected async Task UpdateShowEditCardModal()
        {
            this.ShowEditCardModal = !this.ShowEditCardModal;
        }

        /// <summary>
        /// This Method copy the password to the clipboard.
        /// </summary>
        /// <returns>Void return</returns>
        protected async Task CopyToClipboard()
        {
            await ClipboardService.CopyToClipboard(Data.Password);

            await UpdateShowPassword();
        }

        /// <summary>
        /// This Method is used when a user wants to delete a Card.
        /// </summary>
        /// <returns>Void return</returns>
        /// <exception cref="System.Exception">When a service is not able to process the request</exception>
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
    }
}
