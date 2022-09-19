using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace QLess.Models
{
    public class UserRepository : IUserRepository
    {
        private List<User> users;
        private QLESSDbContext dbContext;

        public UserRepository(QLESSDbContext context)
        {
            dbContext = context;
        }

        public User CreateUser(User user)
        {
            dbContext.Users.Add(user);
            dbContext.SaveChanges();

            return user;
        }

        public User GetUser(int Id)
        {
            return dbContext.Users.Find(Id);
        }

        public User GetUser(string emailAddress)
        {
            return dbContext.Users.FirstOrDefault(x => x.EmailAddress == emailAddress);
        }

        public UserCard AddUserCard(int userId, int cardId)
        {
            UserCard userCard = new UserCard(userId, cardId);
            dbContext.UserCards.Add(userCard);
            dbContext.SaveChanges();

            return userCard;
        }

        public List<UserCard> GetUserCards(int userId)
        {
            return dbContext.UserCards.Where(x => x.UserId == userId).ToList();
        }


    }
}
