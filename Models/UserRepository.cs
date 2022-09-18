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
        public User GetUser(int Id)
        {
            return dbContext.Users.Find(Id);
        }
    }
}
