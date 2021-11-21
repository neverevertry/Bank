using Bank.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Bank.Controllers
{
    public class CardController : Controller
    {
        ICardRepository cardRepository;
        public CardController(ICardRepository card)
        {
            cardRepository = card;
        }

        public ViewResult Index() => View("Index");

        [HttpPost]
        public ViewResult Index(string CardNumb)
        {
            Card GetCard = cardRepository.GetCardByNumber(CardNumb);
            HttpContext.Session.SetString("CardNumber", GetCard.CardNumb);
            if (GetCard != null && GetCard.CardBanned == false)
                return View("Password");
            return View("Error");
        }

        [HttpPost]
        public RedirectToActionResult Password(string password)
        {
            string CardNumb = HttpContext.Session.GetString("CardNumber");
            Card GetCard = cardRepository.GetCardByNumber(CardNumb);
            if (GetCard.Password == password)
                return RedirectToAction("Menu", "CardMenu");
            return RedirectToAction("Error");
        }
    }
}
