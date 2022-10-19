using System;
using Microsoft.AspNetCore.Components;

namespace PasswordManager.Web.Pages
{
    public enum Icons
    {
        Edit,
        Group,
        Delete,
        Copy,
        Star,
        Add,
        Close,
    }

    public class ButtonIconBase:ComponentBase
    {
        [Parameter]
        public Icons Icon { get; set; }

        [Parameter]
        public int Height { get; set; }

        [Parameter]
        public int Width { get; set; }

        [Parameter]
        public EventCallback onClick { get; set; }

        protected async Task callOnClick()
        {
            await onClick.InvokeAsync();
        }
    }
}
