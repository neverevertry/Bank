using Application.DTO;
using Application.Interfaces;
using Bank.Models.ViewModels;
using Domain.Entities;
using Domain.Exceptions;
using Domain.Interface;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;

namespace Bank.Controllers
{
    public class CardMenuController : Controller
    {
        private readonly ICardServices cardServices;

        public CardMenuController(ICardRepository repo, ICardServices services)
        {
            cardServices = services;
        }
        public ViewResult Menu() => View("Menu");

        public ViewResult Widthdraw() => View("Widthdraw");

        [HttpPost]
        public ViewResult Widthdraw(decimal sum)
        {
            string GetCard = HttpContext.Session.GetString("CardNumber");
            Card card = cardServices.GetCardByNumber(GetCard);
            WidthdrawViewDTO widthdrawResult = cardServices.Widthdraw(card, sum);
            ReportViewModel repo = new ReportViewModel
            {
                Balance = widthdrawResult.Balance,
                CardNumb = GetCard,
                Widthdraw = sum,
                DateTime = widthdrawResult.Date
            };
                return View("WidthdrawSucces", repo);
            throw new IncorrectWidthdrawSumException(sum, repo.Balance);
        }

        public ViewResult Balance()
        {
            string GetCard = HttpContext.Session.GetString("CardNumber");
            Card card = cardServices.GetCardByNumber(GetCard);
            BalanceViewDTO DTObalance = cardServices.Balance(card);
            BalanceViewModel balanceViewModel = new BalanceViewModel
            {
                DateTime = DTObalance.Date,
                Balance = DTObalance.Balance,
                CardNumb = GetCard
            };

            return View("Balance", balanceViewModel);
        }

        public ActionResult Exit()
        {
            HttpContext.Session.Clear();
            return RedirectToAction("Exit", "EndSession");
        }
    }
}
