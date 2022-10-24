using System;
namespace PasswordManager.Web.Services.Contracts
{
    /// <summary>
    /// Interface to shape the Clipboard service provider behaviour.
    /// </summary>
    public interface IClipboardService
    {
        /// <summary>
        /// Copy a given data to the Clipboard.
        /// </summary>
        Task CopyToClipboard(string text);
    }
}
