using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace QLess.Models
{
    [Table("Transaction")]
    public class Transaction
    {
        public int Id { get; set; }
        public int CardId { get; set; }
        public float AmountToLoad { get; set; }
        public float CustomerMoney { get; set; }
        public float Change { get; set; }
        public float NewBalance { get; set; }
        public DateTime DateLoaded { get; set; }

        public Transaction(int id, int cardId, float amountToLoad, float customerMoney, float change, float newBalance, DateTime dateLoaded)
        {
            Id = id;
            CardId = cardId;
            AmountToLoad = amountToLoad;
            CustomerMoney = customerMoney;
            Change = change;
            NewBalance = newBalance;
            DateLoaded = dateLoaded;
        }

        public Transaction(int cardId, float amountToLoad, float customerMoney, float change, float newBalance, DateTime dateLoaded)
        {
            CardId = cardId;
            AmountToLoad = amountToLoad;
            CustomerMoney = customerMoney;
            Change = change;
            NewBalance = newBalance;
            DateLoaded = dateLoaded;
        }
    }
}