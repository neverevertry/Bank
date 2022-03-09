using Application.Interfaces;
using Bank.SecurityContext;
using Domain.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Bank.Controllers
{
    [Authorize (Policy = "PartiallyAuthorized")]
    public class CardController : Controller
    {
        private readonly ICardServices service;
        private readonly ISecurityContextRetriever securityContextRetriever;
        public CardController(ICardServices _service, ISecurityContextRetriever _securityContextRetriever)
        {
            service = _service;
            securityContextRetriever = _securityContextRetriever;
        }
        [AllowAnonymous]
        public ViewResult Index() => View();

        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> Index(string CardNumb)
        {
            await service.GetCardByNumber(CardNumb);
            await securityContextRetriever.LogIn(CardNumb);
            

            return View("Password");      
        }

        public ViewResult Password() => View();

        [HttpPost]
        public async Task<IActionResult> Password(string password)
        {
            string CardNumber = securityContextRetriever.GetCardNumber;
            Card card = await service.GetCardByNumber(CardNumber);
            service.ValidatePin(password, card);
            await securityContextRetriever.PassIn(CardNumber);
            return RedirectToAction("Menu", "CardMenu");
        }
    }
}
