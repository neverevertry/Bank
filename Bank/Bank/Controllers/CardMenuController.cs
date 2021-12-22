using Application.DTO;
using Application.Interfaces;
using AutoMapper;
using Bank.Models.ViewModels;
using Domain.Entities;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Bank.Controllers
{
    //[Authorize]
    public class CardMenuController : Controller
    {
        private readonly ICardServices cardService;
        private readonly IMapper mapper;
        private readonly ISecurityContextRetriever securityContextRetriever;

        public CardMenuController(ICardServices _cardService, IMapper _mapper, ISecurityContextRetriever _securityContextRetriever)
        {
            cardService = _cardService;
            mapper = _mapper;
            securityContextRetriever = _securityContextRetriever;
        }


        public ViewResult Menu() => View("Menu");

        public ViewResult Widthdraw() => View("Widthdraw");

        [HttpPost]
        public async Task<IActionResult> Widthdraw(decimal sum)
        {
            string GetCard = securityContextRetriever.GetCardNumber;
            Card card = await cardService.GetCardByNumber(GetCard);

            ReportDto widthdrawResult = cardService.Widthdraw(card, sum);
            var report = mapper.Map<ReportViewModel>(widthdrawResult);
            return View("WidthdrawSucces", report);
        }

        public async Task<IActionResult> Balance()
        {
            string GetCard = securityContextRetriever.GetCardNumber;
            Card card = await cardService.GetCardByNumber(GetCard);

            BalanceDto balanceDto = cardService.Balance(card);

            var balance = mapper.Map<BalanceViewModel>(balanceDto);

            return View("Balance", balance);
        }

        public ActionResult Exit()
        {
            securityContextRetriever.LogOut();
            return RedirectToAction("Index", "Card");
        }
    }
}
