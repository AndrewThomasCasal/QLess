using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace QLess.Models
{
    public class User
    {
        public int Id { get; set; }
        public string Lastname { get; set; }
        public string Firstname { get; set; }
        
        public string EmailAddress { get; set; }
        public string Password { get; set; }
    }
}
