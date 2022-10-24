using System;
using Microsoft.JSInterop;
using PasswordManager.Web.Services.Contracts;

namespace PasswordManager.Web.Services
{
    /// <summary>
    /// Clipboard Service Povider.
    /// </summary>
    public class ClipboardService:IClipboardService
    {
        /// <summary>
        /// Allows the comunication with the Clipboard.
        /// </summary>
        private readonly IJSRuntime _jsInterop;

        /// <summary>
        /// Contructor that initialize the jsInterop.
        /// </summary>
        /// <param name="httpClient">Initialized by dependency injection</param>
        public ClipboardService(IJSRuntime jsInterop)
        {
            _jsInterop = jsInterop;
        }

        /// <summary>
        /// Copies a string to the Clipboard.
        /// </summary>
        /// <param name="text">Strign text to be saved on the clipboard</param>
        public async Task CopyToClipboard(string text)
        {
            await _jsInterop.InvokeVoidAsync("navigator.clipboard.writeText", text);
        }
    }
}

