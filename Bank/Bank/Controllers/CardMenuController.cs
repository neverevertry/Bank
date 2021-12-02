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
        ICardServices cardServices;

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
            WidthdrawResult widthdrawResult = cardServices.Widthdraw(GetCard, sum);
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
            BalanceViewModel balance = new BalanceViewModel {
                Balance = card.CardBalance,
                CardNumb = GetCard,
                DateTime = Convert.ToDateTime(DateTime.Now.ToString("M"))
        };

            return View("Balance", balance);
        }

        public ActionResult Exit()
        {
            HttpContext.Session.Clear();
            return RedirectToAction("Exit", "EndSession");
        }
    }
}
