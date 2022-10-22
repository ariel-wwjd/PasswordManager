using System;
using Microsoft.AspNetCore.Components;
using PasswordManager.Models.Dtos;
using PasswordManager.Web.Services.Contracts;

namespace PasswordManager.Web.Pages
{
    /// <summary>
    /// Enum to ensure the user pass as a parameter the right form type.
    /// </summary>
    public enum FormRole
    {
        Edit,
        Create,
    }

    /// <summary>
    /// Class used to provide the functionality and behaviour to the ModalForm compomnent
    /// </summary>
    public class ModalFormBase: ComponentBase
    {
        /// <summary>
        /// Allows the use of the Card Service to perform a CRUD operations, this service is set by dependency injection.
        /// </summary>
        [Inject]
        public ICardService CardService{ get; set; }

        /// <summary>
        /// Allows the App navigation, this service is set by dependency injection.
        /// </summary>
        [Inject]
        public NavigationManager UriHelper { get; set; }

        /// <summary>
        /// Parameter that receives the form tytle.
        /// </summary>
        [Parameter]
        public string Title { get; set; }

        /// <summary>
        /// Parameter object used to comunicate the card data between the Client and Service.
        /// </summary>
        [Parameter]
        public CardDto Data { get; set; } = new CardDto();

        /// <summary>
        /// Parameter function called when a user clicks on the close or cancel button.
        /// </summary>
        [Parameter]
        public EventCallback onClose { get; set; }

        /// <summary>
        /// Parameter used to define the role of the form.
        /// </summary>
        [Parameter]
        public FormRole Role { get; set; }

        /// <summary>
        /// Boolean value used to verify if all the required data is present.
        /// </summary>
        public bool IsRequiredDataMissing { get; set; }

        /// <summary>
        /// Constructor, initialize the form validation.
        /// </summary>
        public ModalFormBase()
        {
            this.validateData();
        }

        /// <Summary>
        /// Callback caller method for the onClose event. This method can work in a Sync or Async way.
        /// </Summary>
        /// <returns>Void return</returns>
        protected async Task callOnClose()
        {
            await onClose.InvokeAsync();
            StateHasChanged();
        }

        /// <Summary>
        /// Helper function to get the folder name based in the folder Id.
        /// </Summary>
        /// <param name="folderId">The Folder Id</param>
        /// <returns>The name of the foder if it exist or a Invalid Id string</returns>
        private string GetFolderId(int folderId)
        {
            switch (folderId)
            {
                case 2:
                    return "Shopping";
                case 1:
                    return "Browse";
                case 3:
                    return "SocialMedia";
                default:
                    return "Invalid Id";
            }
        }

        /// <Summary>
        /// Funtion used to handle the change on the form inputs.
        /// </Summary>
        /// <param name="label">The input label asigned on every input of the form</param>
        /// <param name="value">The new value typed on the input</param>
        /// <returns>Void return</returns>
        protected void UpdateValues(string value, string label)
        {
            switch (label)
            {
                case "Url:":
                    this.Data.Url = value;
                    break;
                case "Name:":
                    this.Data.ServiceName = value;
                    break;
                case "Folder Id:":
                    this.Data.FolderId = (int)Convert.ToUInt32(value);
                    this.Data.FolderName = this.GetFolderId((int)Convert.ToUInt32(value));
                    StateHasChanged();
                    break;
                case "Username:":
                    this.Data.Username = value;
                    break;
                case "Password:":
                    this.Data.Password = value;
                    break;
                case "Image:":
                    this.Data.Image = value;
                    break;
                default:
                    break;
            }
            this.validateData();
            StateHasChanged();
        }

        /// <Summary>
        /// Funtion used to Save the form changes based on the form role.
        /// </Summary>
        /// <returns>Void return</returns>
        protected async void SaveChanges()
        {
            switch (Role)
            {
                case FormRole.Edit:
                    await CardService.UpdateCard(this.Data);
                    break;
                case FormRole.Create:
                    await CardService.CreateCard(this.Data);
                    break;
                default:
                    break;
            }
            this.UriHelper.NavigateTo(UriHelper.Uri, forceLoad: true);
        }

        /// <Summary>
        /// Function used to validate that all the required fields holds a valid data.
        /// </Summary>
        /// <returns>Void return</returns>
        private void validateData()
        {
            if (this.Data.Url != "" && this.Data.Url != null
                && this.Data.ServiceName!= "" && this.Data.ServiceName != null
                && this.Data.Username != "" && this.Data.Username != null
                && this.Data.Password != "" && this.Data.Password != null)
            {
                this.IsRequiredDataMissing = false;
            }
            else
            {
                this.IsRequiredDataMissing = true;
            }
        }
    }
}
