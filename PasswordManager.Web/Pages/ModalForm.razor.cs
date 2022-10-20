using System;
using Microsoft.AspNetCore.Components;
using PasswordManager.Models.Dtos;
using PasswordManager.Web.Services.Contracts;

namespace PasswordManager.Web.Pages
{
    public enum FormRole
    {
        Edit,
        Create,
    }

    public class ModalFormBase: ComponentBase
    {
        [Inject]
        public ICardService CardService{ get; set; }

        [Inject]
        public NavigationManager UriHelper { get; set; }

        [Parameter]
        public string Title { get; set; }

        [Parameter]
        public CardDto Data { get; set; } = new CardDto();

        [Parameter]
        public EventCallback onClose { get; set; }

        [Parameter]
        public FormRole Role { get; set; }

        public bool IsRequiredDataMissing { get; set; }

        public ModalFormBase()
        {
            this.validateData();
        }

        protected async Task callOnClose()
        {
            await onClose.InvokeAsync();
            StateHasChanged();
        }

        private string GetFolderId(int folder)
        {
            switch (folder)
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

        private void validateData()
        {
            Console.WriteLine(IsRequiredDataMissing);
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

