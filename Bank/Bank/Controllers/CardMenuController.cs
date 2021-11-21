using Bank.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Bank.Controllers
{
    public class CardMenuController : Controller
    {
        ICardRepository cardRepository;
        IOptionRepository optionRepository;

        public CardMenuController(ICardRepository repo, IOptionRepository option)
        {
            cardRepository = repo;
            optionRepository = option;
        }
        public ViewResult Menu() => View("Menu");

        public ViewResult Widthdraw() => View("Widthdraw");

        [HttpPost]
        public ViewResult Widthdraw(decimal sum)
        {
            string GetCard = HttpContext.Session.GetString("CardNumber");
            Card card = cardRepository.GetCardByNumber(GetCard);
            CardLogic cardLogic = new CardLogic(optionRepository);
            if (cardLogic.PossibleWidthdraw(card, sum))
                return View("WidthdrawSucces", card);
            return View("Error");
        }

        public ViewResult Balance()
        {
            string GetCard = HttpContext.Session.GetString("CardNumber");
            Card card = cardRepository.GetCardByNumber(GetCard);
            CardLogic cardLogic = new CardLogic(optionRepository);
            cardLogic.InfoOperation(card);
            return View("Balance", card);
        }
    }
}
