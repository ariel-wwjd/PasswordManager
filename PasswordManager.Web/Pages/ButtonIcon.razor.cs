using System;
using Microsoft.AspNetCore.Components;

namespace PasswordManager.Web.Pages
{
    /// <summary>
    /// Enum used to ensure the user pass as a parameter the right icon name.
    /// </summary>
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

    /// <summary>
    /// Class used to provide the functionality and behaviour to the ButtonIcon compomnent
    /// </summary>
    public class ButtonIconBase:ComponentBase
    {
        /// <summary>
        /// Parameter that defines the icon to be displayed
        /// </summary>
        [Parameter]
        public Icons Icon { get; set; }

        /// <summary>
        /// Callback parameter used as an event asigned and fired when a user makes a click on the button
        /// </summary>
        [Parameter]
        public EventCallback onClick { get; set; }

        /// <summary>
        /// Method used to invoke the onClick button event. This method works in both Sync or Async way.
        /// </summary>
        /// <returns>Void return</returns>
        protected async Task callOnClick()
        {
            await onClick.InvokeAsync();
        }
    }
}
