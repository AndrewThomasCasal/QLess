using QLess.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace QLess.ViewModels
{
    public class TransitViewModel
    {
        public DateTime DateSelected { get; set; }
        public Card Card { get; set; }
        public List<CardHistory> CardHistories { get; set; }
        public TransitViewModel()
        {

        }

        public TransitViewModel(DateTime dateSelected, Card card, List<CardHistory> cardHistories)
        {
            DateSelected = dateSelected;
            Card = card;
            CardHistories = cardHistories;
        }
    }
}
