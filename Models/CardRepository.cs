using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace QLess.Models
{
    public class CardRepository
    {
        private QLESSDbContext dbContext;

        public CardRepository(QLESSDbContext context)
        {
            dbContext = context;
        }

        public Card AddCard(int Id, float initialLoad, DateTime validityDate, string seniorCitizenNum, string pwdNum)
        {
            Card card = new Card(Id, initialLoad, validityDate, null, seniorCitizenNum, pwdNum);
            dbContext.Cards.Add(card);
            dbContext.SaveChanges();

            return card;
        }

        public Card GetCard(int Id)
        {
            return dbContext.Cards.Find(Id);
        }

        public CardType GetCardType(int Id)
        {
            return dbContext.CardTypes.Find(Id);
        }

        public CardHistory AddCardHistory(int cardId, int transactiontypeId, DateTime dateUsed, float amountChange, float newBalance, int? stationId, float? appliedDiscount)
        {
            CardHistory cardHistory = new CardHistory(cardId, transactiontypeId, dateUsed, amountChange, newBalance, null, appliedDiscount);
            dbContext.CardHistories.Add(cardHistory);
            dbContext.SaveChanges();

            return cardHistory;
        }

        public List<CardHistory> GetCardHistories(int cardId)
        {
            return dbContext.CardHistories.Where(x => x.CardId == cardId).ToList();
        }

        public Card UpdateCard(Card updatedCard)
        {
            var card = dbContext.Cards.Attach(updatedCard);
            card.State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            dbContext.SaveChanges();

            return updatedCard;
        }
    }
}
