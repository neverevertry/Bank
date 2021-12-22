using Application.Interfaces;
using Domain.Entities;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Bank.Controllers
{
    public class CardController : Controller
    {
        private readonly ICardServices service;
        private readonly IClaimsCookie claimsCookie;
        public CardController(ICardServices _service, IClaimsCookie _claimsCookie)
        {
            service = _service;
            claimsCookie = _claimsCookie;
        }

        public ViewResult Index() => View();

        [HttpPost]
        public async Task<IActionResult> Index(string CardNumb)
        {
            await service.GetCardByNumber(CardNumb);
            await claimsCookie.SignIn(CardNumb);

            return View("Password");          
        }

        public ViewResult Password() => View();

        [HttpPost]
        public async Task<IActionResult> Password(string password)
        {
            string CardNumber = claimsCookie.GetCardCookie();
            Card card = await service.GetCardByNumber(CardNumber);
            service.ValidatePin(password, card);
            return RedirectToAction("Menu", "CardMenu");
        }
    }
}
