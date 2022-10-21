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
    /// Button Component class
    /// </summary>
    public class ButtonBase:ComponentBase
    {
        /// <summary>
        /// The label of the button, preferably use upper case. If there is no label it will be BUTTON by default
        /// </summary>
        [Parameter]
        public string Label { get; set; } = "BUTTON";

        /// <summary>
        /// The type defines The behavior of the button, by default is button
        /// </summary>
        [Parameter]
        public string Type { get; set; } = "button";

        /// <summary>
        /// Cancels the event propagation when the event is cancelable
        /// </summary>
        [Parameter]
        public Boolean PreventDefault { get; set; } = false;

        /// <summary>
        /// Defines the button behaviour using css only
        /// </summary>
        [Parameter]
        public ButtonClassName ClassNames { get; set; }

        /// <summary>
        /// Call back event asigned and fired when a user makes a click on the button
        /// </summary>
        [Parameter]
        public EventCallback onClick { get; set; }

        /// <Summary>
        /// Callback caller async method for the onClick button event. This method can also work in a Sync way.
        /// </Summary>
        protected async Task callOnClick()
        {
            await onClick.InvokeAsync();
        }
    }
}
