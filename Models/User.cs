using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace QLess.Models
{
    [Table("User")]
    public class User
    {
        public int Id { get; set; }
        public string Lastname { get; set; }
        public string Firstname { get; set; }
        
        public string EmailAddress { get; set; }
        public string Password { get; set; }

        public User()
        {

        }

        public User(string lastname, string firstname, string emailAddress)
        {
            Lastname = lastname;
            Firstname = firstname;
            EmailAddress = emailAddress;
        }

        public User(string lastname, string firstname, string emailAddress, string hashedPassword)
        {
            Lastname = lastname;
            Firstname = firstname;
            EmailAddress = emailAddress;
            Password = hashedPassword;
        }
    }

   
}
