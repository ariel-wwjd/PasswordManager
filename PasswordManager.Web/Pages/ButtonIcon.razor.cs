using System;
using Microsoft.AspNetCore.Components;

namespace PasswordManager.Web.Pages
{
    /// <summary>
    /// Enum to ensure the user pass as a parameter the right icon name.
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
    /// Button Icon Component class, this component shows only an icon instead of a label
    /// </summary>
    public class ButtonIconBase:ComponentBase
    {
        /// <summary>
        /// Defines the icon to be displayed
        /// </summary>
        [Parameter]
        public Icons Icon { get; set; }

        /// <summary>
        /// Call back event asigned and fired when a user makes a click on the button
        /// </summary>
        [Parameter]
        public EventCallback onClick { get; set; }

        /// <summary>
        /// Callback caller async method for the onClick button event. This method can also work in a Sync way.
        /// </summary>
        protected async Task callOnClick()
        {
            await onClick.InvokeAsync();
        }
    }
}
