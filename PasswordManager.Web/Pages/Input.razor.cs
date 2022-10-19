using System;
using Microsoft.AspNetCore.Components;

namespace PasswordManager.Web.Pages
{
    public class InputBase:ComponentBase
    {
        [Parameter]
        public string Label { get; set; }

        [Parameter]
        public string Value { get; set; }

        [Parameter]
        public string Placeholder { get; set; }

        [Parameter]
        public string Type { get; set; }

        [Parameter]
        public Action<string, string> onChange { get; set; }

        protected void callOnChange(ChangeEventArgs args)
        {
            Value = (string)args.Value;
            onChange.Invoke(Value, Label);
        }
    }
}
