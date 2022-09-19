using QLess.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace QLess.ViewModels
{
    public class ReloadViewModel
    {
        public Card Card { get; set; }
        public List<Transaction> Transactions { get; set; }
        public int CustomerMoney { get; set; }
        public int AmountToLoad { get; set; }

        public ReloadViewModel(Card card, List<Transaction> transactions)
        {
            Card = card;
            Transactions = transactions;
        }
    }
}
