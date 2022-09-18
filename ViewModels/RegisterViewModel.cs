using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace QLess.ViewModels
{
    public class RegisterViewModel
    {
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public string EmailAddress { get; set; }
        public string Password { get; set; }
        public string ConfirmPassword { get; set; }
    }
}
