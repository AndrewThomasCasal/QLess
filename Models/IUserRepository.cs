using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace QLess.Models
{
    public interface IUserRepository
    {
        //User CreateUser(User user);
        User GetUser(int Id);
        //User UpdateUser(User user);
        //User DeleteUser(int Id);
    }
}
