using Application.DTO;
using Application.Interfaces;
using AutoMapper;
using Bank.Models.ViewModels;
using Domain.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Bank.Controllers
{
    public class CardMenuController : Controller
    {
        private readonly ICardServices _cardService;
        private readonly IMapper _mapper;

        public CardMenuController(ICardServices cardService, IMapper mapper)
        {
            _cardService = cardService;
            _mapper = mapper;
        }


        public ViewResult Menu() => View("Menu");

        public ViewResult Widthdraw() => View("Widthdraw");

        [HttpPost]
        public async Task<IActionResult> Widthdraw(decimal sum)
        {
            string GetCard = HttpContext.Session.GetString("CardNumber");
            Card card = await _cardService.GetCardByNumber(GetCard);

            ReportDto widthdrawResult = _cardService.Widthdraw(card, sum);
            var report = _mapper.Map<ReportViewModel>(widthdrawResult);
            return View("WidthdrawSucces", report);
        }

        public async Task<IActionResult> Balance()
        {
            string GetCard = HttpContext.Session.GetString("CardNumber");
            Card card = await _cardService.GetCardByNumber(GetCard);

            BalanceDto balanceDto = _cardService.Balance(card);

            var balance = _mapper.Map<BalanceViewModel>(balanceDto);

            return View("Balance", balance);
        }

        public ActionResult Exit()
        {
            HttpContext.Session.Clear();
            return RedirectToAction("Index", "Card");
        }
    }
}
