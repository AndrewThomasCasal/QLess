using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using QLess.Models;
using QLess.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace QLess.Controllers
{
    public class TransitController : Controller
    {
        private readonly CardRepository _cardRepository;
        private readonly IUserRepository _userRepository;
        public TransitController(CardRepository cardRepository, IUserRepository userRepository)
        {
            _cardRepository = cardRepository;
            _userRepository = userRepository;
        }

        public IActionResult Index()
        {
            int userId = 1;
            //int userId = int.Parse(HttpContext.Session.GetString("UserId"));
            User user = _userRepository.GetUser(userId);
            
            List<UserCard> userCards = _userRepository.GetUserCards(userId);
            Card selectedCard = _cardRepository.GetCard(userCards.LastOrDefault().CardId);
            List<CardHistory> cardHistories = _cardRepository.GetCardHistories(selectedCard.Id).OrderByDescending(x => x.Id).ToList();

            TransitViewModel transitViewModel = new TransitViewModel(DateTime.Now.Date, selectedCard, cardHistories);
            HttpContext.Session.SetString("selectedCardId", selectedCard.Id.ToString());

            return View(transitViewModel);
        }

        public IActionResult UseCard(DateTime dateSelected)
        {
            int selectedCardId = int.Parse(HttpContext.Session.GetString("selectedCardId"));
            Card selectedCard = _cardRepository.GetCard(selectedCardId);
            CardType cardType = _cardRepository.GetCardType(selectedCard.CardTypeId);
            List<CardHistory> cardHistories = _cardRepository.GetCardHistories(selectedCard.Id);

            //Use
            int transactionTypeId = 2; 

            float discountPercentage = 0;
            float discount = 0;
            float newBalance = 0;
            
            //To simulate changing date
            DateTime newDate = dateSelected.Add(DateTime.Now.TimeOfDay);

            if (cardType.Id == 1)
            {
                newBalance = selectedCard.Balance - cardType.RegularRate;
            }
            else
            {
                int count = cardHistories.Count(x => x.DateUsed.Date == dateSelected && x.TransactionTypeId == transactionTypeId);

                //First trip + Succeeding trips
                int maxUsePerDay = cardType.AdditionalDiscountMaxUsePerDay + 1;

                if (count == 0)
                {
                    discount = cardType.RegularRate * cardType.BaseDiscount;
                    discountPercentage = cardType.BaseDiscount * 100;
                    newBalance = selectedCard.Balance - (cardType.RegularRate - discount);
                }
                else if (count <= cardType.AdditionalDiscountMaxUsePerDay)
                {
                    discount = cardType.RegularRate * (cardType.BaseDiscount + cardType.AdditionalDiscount);
                    discountPercentage = (cardType.BaseDiscount + cardType.AdditionalDiscount) * 100;
                    newBalance = selectedCard.Balance - (cardType.RegularRate - discount);
                }
                else
                {
                    discount = cardType.RegularRate * cardType.BaseDiscount;
                    discountPercentage = cardType.BaseDiscount * 100;
                    newBalance = selectedCard.Balance - (cardType.RegularRate - discount);
                }
                
            }

            //Update card    
            selectedCard.Balance = newBalance;
            selectedCard.LastUsedDate = newDate;
            selectedCard.ValidityDate = newDate.AddYears(cardType.ValidityPeriod);

            Card updatedCard = _cardRepository.UpdateCard(selectedCard);
            CardHistory cardHistory = _cardRepository.AddCardHistory(selectedCardId, 2, newDate, -(cardType.RegularRate - discount), newBalance, null, discountPercentage);
            cardHistories.Add(cardHistory);
            cardHistories = cardHistories.OrderByDescending(x => x.Id).ToList();

            TransitViewModel transitViewModel = new TransitViewModel(dateSelected, selectedCard, cardHistories);

            return View("Index", transitViewModel);
        }
    }
}
