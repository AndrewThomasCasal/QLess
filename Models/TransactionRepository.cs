using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace QLess.Models
{
    public class TransactionRepository
    {
        private QLESSDbContext dbContext;

        public TransactionRepository(QLESSDbContext context)
        {
            dbContext = context;
        }

        public Transaction AddTransaction(int cardId, float amountToLoad, float customerMoney, float change, float newBalance, DateTime dateLoaded)
        {
            Transaction transaction = new Transaction(cardId, amountToLoad, customerMoney, change, newBalance, dateLoaded);

            dbContext.Transactions.Add(transaction);
            dbContext.SaveChanges();

            return transaction;
        }

        public List<Transaction> GetTransactions(int cardId)
        {
            return dbContext.Transactions.Where(x => x.CardId == cardId).ToList();
        }
    }
}
