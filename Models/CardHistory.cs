using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace QLess.Models
{
    [Table("CardHistory")]
    public class CardHistory
    {
        public int Id { get; set; }
        public int CardId { get; set; }
        public int TransactionTypeId { get; set; }
        public DateTime DateUsed { get; set; }
        public float AmountChange { get; set; }
        public float NewBalance { get; set; }
        public int? StationId { get; set; }
        public float? AppliedDiscount { get; set; }

        public CardHistory(int id, int cardId, int transactionTypeId, DateTime dateUsed, float amountChange, float newBalance, int? stationId, float? appliedDiscount)
        {
            Id = id;
            CardId = cardId;
            TransactionTypeId = transactionTypeId;
            DateUsed = dateUsed;
            AmountChange = amountChange;
            NewBalance = newBalance;
            StationId = stationId;
            AppliedDiscount = appliedDiscount;
        }

        public CardHistory(int cardId, int transactionTypeId, DateTime dateUsed, float amountChange, float newBalance, int? stationId, float? appliedDiscount)
        {
            CardId = cardId;
            TransactionTypeId = transactionTypeId;
            DateUsed = dateUsed;
            AmountChange = amountChange;
            NewBalance = newBalance;
            StationId = stationId;
            AppliedDiscount = appliedDiscount;
        }
    }
}
