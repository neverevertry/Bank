using Application.Interfaces;
using Bank.SecurityContext;
using Domain.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Bank.Controllers
{
    //[Authorize]
    public class CardController : Controller
    {
        private readonly ICardServices service;
        private readonly ISecurityContextRetriever claimsCookie;
        public CardController(ICardServices _service, ISecurityContextRetriever _claimsCookie)
        {
            service = _service;
            claimsCookie = _claimsCookie;
        }
        [AllowAnonymous]
        public ViewResult Index() => View();

        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> Index(string CardNumb)
        {
            await service.GetCardByNumber(CardNumb);
            await claimsCookie.LogIn(CardNumb);

            return View("Password");          
        }

        public ViewResult Password() => View();

        [HttpPost]
        public async Task<IActionResult> Password(string password)
        {
            string CardNumber = claimsCookie.GetCardNumber;
            Card card = await service.GetCardByNumber(CardNumber);
            service.ValidatePin(password, card);
            return RedirectToAction("Menu", "CardMenu");
        }
    }
}
