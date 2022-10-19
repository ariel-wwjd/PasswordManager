using System;
using Microsoft.AspNetCore.Components;

namespace PasswordManager.Web.Pages
{
    public class ImageBase:ComponentBase
    {
        [Parameter]
        public string Src { get; set; }
        [Parameter]
        public string Alt { get; set; }
    }
}

