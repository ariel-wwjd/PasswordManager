using System;
using Microsoft.AspNetCore.Components;

namespace PasswordManager.Web.Pages
{
    /// <summary>
    /// Class used to provide the functionality and behaviour to the Image compomnent
    /// </summary>
    public class ImageBase:ComponentBase
    {
        /// <summary>
        /// Parameter that defines the source of the image.
        /// </summary>
        [Parameter]
        public string Src { get; set; }

        /// <summary>
        /// Parameter that defines an alternative string to be displayed when the image cannot be displayed.
        /// </summary>
        [Parameter]
        public string Alt { get; set; }
    }
}

