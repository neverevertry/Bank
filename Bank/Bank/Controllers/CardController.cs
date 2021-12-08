using Application.Interfaces;
using Domain.Entities;
using Domain.Exceptions;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;

namespace Bank.Controllers
{
    public class CardController : Controller
    {
        private readonly ICardServices service;
        public CardController(ICardServices _service)
        {
            service = _service;
        }

        public ViewResult Index() => View("Index");

        [HttpPost]
        public ViewResult Index(string CardNumb)
        {
           Card card = service.GetCardByNumber(CardNumb);
           if (card != null)
           {
                if (card.CardBanned)
                    throw new BlockedCardException(CardNumb);
                HttpContext.Session.SetString("CardNumber", service.GetCardByNumber(CardNumb).CardNumb);
                return View("Password");
           }
            throw new IncorrectLoginException(CardNumb);
        }

        public ViewResult Password() => View("Password");

        [HttpPost]
        public ActionResult Password(string password)
        {
            string CardNumb = HttpContext.Session.GetString("CardNumber");
            Card card = service.GetCardByNumber(CardNumb);
            if (service.IsPinCorrect(password, card))
                return RedirectToAction("Menu", "CardMenu");
            throw new IncorrectPinException();
        }
    }
}
