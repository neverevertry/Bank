using Application.DTO;
using Application.Interfaces;
using AutoMapper;
using Bank.Models.ViewModels;
using Bank.SecurityContext;
using Domain.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Bank.Controllers
{
    [Authorize]
    public class CardMenuController : Controller
    {
        private readonly ICardServices _cardService;
        private readonly IMapper _mapper;
        private readonly ISecurityContextRetriever _claimsCookie;

        public CardMenuController(ICardServices cardService, IMapper mapper, ISecurityContextRetriever claimsCookie)
        {
            _cardService = cardService;
            _mapper = mapper;
            _claimsCookie = claimsCookie;
        }


        public ViewResult Menu() => View("Menu");

        public ViewResult Widthdraw() => View("Widthdraw");

        [HttpPost]
        public async Task<IActionResult> Widthdraw(decimal sum)
        {
            string GetCard = _claimsCookie.GetCardNumber;
            Card card = await _cardService.GetCardByNumber(GetCard);

            ReportDto widthdrawResult = _cardService.Widthdraw(card, sum);
            var report = _mapper.Map<ReportViewModel>(widthdrawResult);
            return View("WidthdrawSucces", report);
        }

        public async Task<IActionResult> Balance()
        {
            string GetCard = _claimsCookie.GetCardNumber;
            Card card = await _cardService.GetCardByNumber(GetCard);

            BalanceDto balanceDto = _cardService.Balance(card);

            var balance = _mapper.Map<BalanceViewModel>(balanceDto);

            return View("Balance", balance);
        }

        public ActionResult Exit()
        {
            _claimsCookie.LogOut();
            return RedirectToAction("Index", "Card");
        }
    }
}
