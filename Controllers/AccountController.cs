using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using QLess.Models;
using QLess.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace QLess.Controllers
{
    public class AccountController : Controller
    {
        //private readonly ILogger<AccountController> _logger;
        private readonly IUserRepository _userRepository;

        //public AccountController(ILogger<AccountController> logger)
        //{
        //    _logger = logger;
        //}

        public AccountController(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public IActionResult Register()
        {
            return View();
        }

        public IActionResult RegisterUser(RegisterViewModel registerViewModel)
        {

            if (registerViewModel.Password != registerViewModel.ConfirmPassword)
            {

            }

            User user = new User(registerViewModel.Lastname,
                registerViewModel.Firstname,
                registerViewModel.EmailAddress,
                registerViewModel.Password);

            User createdUser = _userRepository.CreateUser(user);

            if (createdUser == null)
            {
                return View();
            }
            else
            {
                return RedirectToAction("Login");
            }  
        }

        public IActionResult Login()
        {
            return View();
        }

        public IActionResult LoginUser(LoginViewModel loginViewModel)
        {
            User user = _userRepository.GetUser(loginViewModel.EmailAddress);

            if (user == null)
            {
                return View("Login");
            }
            else
            {
                if (user.Password == loginViewModel.Password)
                {

                    HttpContext.Session.SetString("UserId", user.Id.ToString());
                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    return View("Login");
                }
            }

            
        }
    }
}
