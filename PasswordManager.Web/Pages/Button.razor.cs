using System;
using Microsoft.AspNetCore.Components;

namespace PasswordManager.Web.Pages
{
    /// <summary>
    /// Enum to ensure the user pass as a parameter the right class name.
    /// </summary>
    public enum ButtonClassName
    {
        enabled,
        disabled,
    }

    /// <summary>
    /// Class used to provide the functionality and behaviour to the Button compomnent
    /// </summary>
    public class ButtonBase:ComponentBase
    {
        /// <summary>
        /// Parameter used to label the button, preferably use upper case. If there is no label it will be BUTTON by default.
        /// </summary>
        [Parameter]
        public string Label { get; set; } = "BUTTON";

        /// <summary>
        /// Parameter used to define the behavior of the button, by default is button.
        /// </summary>
        [Parameter]
        public string Type { get; set; } = "button";

        /// <summary>
        /// Parameter used to cancel the event propagation when the event is cancelable.
        /// </summary>
        [Parameter]
        public Boolean PreventDefault { get; set; } = false;

        /// <summary>
        /// Parameter used tyo define the button behaviour using css classes only.
        /// </summary>
        [Parameter]
        public ButtonClassName ClassNames { get; set; }

        /// <summary>
        /// Parameter used to set a callback event asigned and fired when a user makes a click on the button.
        /// </summary>
        [Parameter]
        public EventCallback onClick { get; set; }

        /// <Summary>
        /// Callback caller async method for the onClick button event. This method can also work in a Sync way.
        /// </Summary>
        /// <returns>Void return</returns>
        protected async Task callOnClick()
        {
            await onClick.InvokeAsync();
        }
    }
}
