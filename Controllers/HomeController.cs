using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using QLess.Models;
using QLess.ViewModels;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace QLess.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IUserRepository _userRepository;
        private readonly CardRepository _cardRepository;
        private readonly TransactionRepository _transactionRepository;

        public HomeController(
            ILogger<HomeController> logger,
            IUserRepository userRepository,
            CardRepository cardRepository,
            TransactionRepository transactionRepository)
        {
            _logger = logger;
            _userRepository = userRepository;
            _cardRepository = cardRepository;
            _transactionRepository = transactionRepository;
        }

        public IActionResult Index()
        {
            string userId = HttpContext.Session.GetString("UserId");

            if (string.IsNullOrWhiteSpace(userId))
            {
                HttpContext.Session.SetString("UserId", "1");
            }
            
            //return RedirectToAction("Index", "Transit");
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        public IActionResult BuyQLessTransportCard()
        {
            User user = _userRepository.GetUser(int.Parse(HttpContext.Session.GetString("UserId")));
            
            int cardTypeId = 1;
            CardType cardType = _cardRepository.GetCardType(cardTypeId);
            Card card = _cardRepository.AddCard(cardType.Id, cardType.InitialLoad, DateTime.Now.AddYears(cardType.ValidityPeriod), null, null);

            _userRepository.AddUserCard(user.Id, card.Id);
            _transactionRepository.AddTransaction(card.Id, cardType.InitialLoad, cardType.InitialLoad, 0, cardType.InitialLoad, DateTime.Now);
            _cardRepository.AddCardHistory(card.Id, 1, DateTime.Now, cardType.InitialLoad, cardType.InitialLoad, null, null);

            HttpContext.Session.SetString("CardId", card.Id.ToString());

            return RedirectToAction("Index", "Transit");
        }

        public IActionResult QLessDiscountedTransportCard()
        {
            return View();
        }

        public IActionResult BuyQLESSDiscountedTransportCard(string discountTypeRadios, string seniorCitizenNum, string pwdNum)
        {
            User user = _userRepository.GetUser(int.Parse(HttpContext.Session.GetString("UserId")));
            bool isProvidedNumValid = true;
            string errorMessage = "";

            if (discountTypeRadios == "1")
            {
                Regex regex = new Regex(@"^[0-9]{2}-[0-9]{4}-[0-9]{4}");

                if (string.IsNullOrWhiteSpace(seniorCitizenNum))
                {
                    isProvidedNumValid = false;
                    errorMessage += "Senior Citizen Number is empty";
                }
                else
                {
                    if (seniorCitizenNum.Length != 12 || !regex.IsMatch(seniorCitizenNum))
                    {
                        isProvidedNumValid = false;
                        errorMessage += "Senior Citizen Number must be 10 character length with format: ##-####-####";
                    }
                }

                
            }
            else
            {
                Regex regex = new Regex(@"^[0-9]{4}-[0-9]{4}-[0-9]{4}");

                if (string.IsNullOrWhiteSpace(pwdNum))
                {
                    isProvidedNumValid = false;
                    errorMessage += "PWD Number is empty";
                }
                else
                {
                    if (pwdNum.Length != 14 || !regex.IsMatch(pwdNum))
                    {
                        isProvidedNumValid = false;
                        errorMessage += "PWD Number must be 12 character length with format: ####-####-####";
                    }
                }
                
            }

            if (isProvidedNumValid)
            {
                //Discounted
                int cardTypeId = 2;

                CardType cardType = _cardRepository.GetCardType(cardTypeId);
                Card card = _cardRepository.AddCard(cardType.Id, cardType.InitialLoad, DateTime.Now.AddYears(cardType.ValidityPeriod), seniorCitizenNum, pwdNum);

                _userRepository.AddUserCard(user.Id, card.Id);
                _transactionRepository.AddTransaction(card.Id, cardType.InitialLoad, cardType.InitialLoad, 0, cardType.InitialLoad, DateTime.Now);
                _cardRepository.AddCardHistory(card.Id, 1, DateTime.Now, cardType.InitialLoad, cardType.InitialLoad, null, null);

                HttpContext.Session.SetString("CardId", card.Id.ToString());

                return RedirectToAction("Index", "Transit");
            }
            else
            {
                TempData["QLESSDiscountedTransportCardAlert"] = errorMessage;
                return RedirectToAction("QLessDiscountedTransportCard", "Home");
            }
            
        }

        public IActionResult Reload()
        {
            User user = _userRepository.GetUser(int.Parse(HttpContext.Session.GetString("UserId")));
            UserCard userCard = _userRepository.GetUserCards(user.Id).LastOrDefault();
            Card card = _cardRepository.GetCard(userCard.Id);
            List<Transaction> transactions = _transactionRepository.GetTransactions(card.Id).OrderByDescending(x => x.Id).ToList();

            ReloadViewModel reloadViewModel = new ReloadViewModel(card, transactions);

            return View("Reload", reloadViewModel);
        }

        public IActionResult ReloadCard(int customerMoney, int amountToLoad)
        {
            User user = _userRepository.GetUser(int.Parse(HttpContext.Session.GetString("UserId")));
            UserCard userCard = _userRepository.GetUserCards(user.Id).LastOrDefault();
            Card card = _cardRepository.GetCard(userCard.Id);

            bool isTransactionValid = true;
            string errorMessage = "";

            if (amountToLoad < 100)
            {
                isTransactionValid = false;
                errorMessage += "Amount to load less than 100. ";
            }

            if (amountToLoad > 1000)
            {
                isTransactionValid = false;
                errorMessage += "Amount to load greater than 1000. ";
            }

            if (amountToLoad > customerMoney)
            {
                isTransactionValid = false;
                errorMessage += "Amount to load greater than money inserted. ";
            }

            if (card.Balance >= 10000)
            {
                isTransactionValid = false;
                errorMessage += "Amount to load will exceed the maximum balance of P10,000. ";
            }

            if (isTransactionValid)
            {
                float change = 0, 
                      newBalance = 0;

                if (card.Balance + amountToLoad > 10000)
                {
                    change = Math.Abs((10000 - card.Balance) - amountToLoad);
                    newBalance = 10000;
                }
                else
                {
                    change = customerMoney - amountToLoad;
                    newBalance = card.Balance + amountToLoad;
                }

                Transaction transaction = _transactionRepository.AddTransaction(card.Id, amountToLoad, customerMoney, change, newBalance, DateTime.Now);
                CardHistory cardHistory = _cardRepository.AddCardHistory(card.Id, 1, DateTime.Now, amountToLoad, newBalance, null, null);
                List<Transaction> transactions = _transactionRepository.GetTransactions(card.Id).OrderByDescending(x => x.Id).ToList();

                card.Balance = newBalance;
                Card updatedCard = _cardRepository.UpdateCard(card);

                ReloadViewModel reloadViewModel = new ReloadViewModel(updatedCard, transactions);

                return View("Reload", reloadViewModel);
            }
            else
            {
                List<Transaction> transactions = _transactionRepository.GetTransactions(card.Id).OrderByDescending(x => x.Id).ToList();
                ReloadViewModel reloadViewModel = new ReloadViewModel(card, transactions);

                TempData["ReloadAlert"] = errorMessage;
                return View("Reload", reloadViewModel);
            }
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
