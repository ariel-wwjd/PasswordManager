using System;
using Microsoft.AspNetCore.Components;
using PasswordManager.Models.Dtos;

namespace PasswordManager.Web.Pages
{
    /// <summary>
    /// Class used to provide the functionality and behaviour to the CardList compomnent
    /// </summary>
    public class CardListBase:ComponentBase
    {
        /// <summary>
        /// Parameter that receives a list of CardsDto.
        /// </summary>
        [Parameter]
        public List<CardDto> Cards { get; set; }

        /// <summary>
        /// Parameter that receives a list of grouped cards based on the folder where the card belongs.
        /// </summary>
        [Parameter]
        public IEnumerable<IGrouping<int, CardDto>> GroupedCards { get; set; }

        /// <summary>
        /// List of cards used as a helper for the render purpuses.
        /// </summary>
        protected List<CardDto> CurrentGroup { get; set; }
    }
}

