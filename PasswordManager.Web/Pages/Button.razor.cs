using System;
using Microsoft.AspNetCore.Components;

namespace PasswordManager.Web.Pages
{
    public class ButtonBase:ComponentBase
    {
        [Parameter]
        public string Label { get; set; } = "BUTTON";

        [Parameter]
        public string Type { get; set; } = "button";

        [Parameter]
        public Boolean PreventDefault { get; set; } = false;

        [Parameter]
        public EventCallback onClick { get; set; }

        /// <Summary>
        /// Callback caller async method for the onClick button event.
        /// This method can work also in a Sync way.
        /// </Summary>
        protected async Task callOnClick()
        {
            await onClick.InvokeAsync();
        }
    }
}
