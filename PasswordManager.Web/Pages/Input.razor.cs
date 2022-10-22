using System;
using Microsoft.AspNetCore.Components;

namespace PasswordManager.Web.Pages
{
    /// <summary>
    /// Class used to provide the functionality and behaviour to the Input compomnent
    /// </summary>
    public class InputBase:ComponentBase
    {
        /// <summary>
        /// Parameter that receives the label of the Input. ther label is also used to identify the input, should be unique for every form
        /// </summary>
        [Parameter]
        public string Label { get; set; }

        /// <summary>
        /// Parameter that receives an initial value and is used to set the inputs value
        /// </summary>
        [Parameter]
        public string Value { get; set; }

        /// <summary>
        /// Parameter that receives placeholder for the input.
        /// </summary>
        [Parameter]
        public string Placeholder { get; set; }

        /// <summary>
        /// Parameter that defines the behaviour for the Input Component.
        /// </summary>
        [Parameter]
        public string Type { get; set; }

        /// <summary>
        /// Parameter that enables a special behaviour when the data on the Input Component is required.
        /// </summary>
        [Parameter]
        public bool IsRequired { get; set; }

        /// <summary>
        /// Parameter that receives a message to show when the data of the Input Component is not present.
        /// </summary>
        [Parameter]
        public string RequiredMessage { get; set; }

        /// <summary>
        /// Parameter that receives a callback function executed when de data of the input changes.
        /// </summary>
        [Parameter]
        public Action<string, string> onChange { get; set; }

        /// <summary>
        /// Method used to invoke the onChange input event.
        /// </summary>
        /// <param name="args">contains the data when a user types on the input</param>
        /// <returns>Void return</returns>
        protected void callOnChange(ChangeEventArgs args)
        {
            Value = (string)args.Value;
            onChange.Invoke(Value, Label);
        }
    }
}
