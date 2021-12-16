using Application.Interfaces;
using Domain.Entities;
using Domain.Exceptions;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace Bank.Controllers
{
    public class CardController : Controller
    {
        private readonly ICardServices service;
        public CardController(ICardServices _service)
        {
            service = _service;
        }

        public ViewResult Index() => View();

        [HttpPost]
        public async Task<IActionResult> Index(string CardNumb)
        {
           await service.GetCardByNumber(CardNumb);
           HttpContext.Session.SetString("CardNumber",CardNumb);
           return View("Password");          
        }

        public ViewResult Password() => View();

        [HttpPost]
        public async Task<IActionResult> Password(string password)
        {
            string CardNumb = HttpContext.Session.GetString("CardNumber");
            Card card = await service.GetCardByNumber(CardNumb);
            service.ValidatePin(password, card);
            return RedirectToAction("Menu", "CardMenu");
        }
    }
}
