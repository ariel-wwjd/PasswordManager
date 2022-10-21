using System;
using Microsoft.AspNetCore.Components;
using PasswordManager.Models.Dtos;

namespace PasswordManager.Web.Pages
{
    public class CardListBase:ComponentBase
    {
        [Parameter]
        public List<CardDto> Cards { get; set; }

        [Parameter]
        public IEnumerable<IGrouping<int, CardDto>> GroupedCards { get; set; }

        public List<CardDto> CurrentGroup { get; set; }
    }
}

