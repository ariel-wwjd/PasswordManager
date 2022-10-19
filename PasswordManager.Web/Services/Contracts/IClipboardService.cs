using System;
namespace PasswordManager.Web.Services.Contracts
{
    public interface IClipboardService
    {
        Task CopyToClipboard(string text);
    }
}

