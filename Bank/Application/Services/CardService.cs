using Application.DTO;
using Application.Interfaces;
using Domain.Entities;
using Domain.Exceptions;
using Domain.Interface;

namespace Application
{
    public class CardService : ICardServices
    {
        ICardRepository cardRepo;
        IOperationService operationService;
        private static int numberOfApptems = 0;
        public CardService(ICardRepository _cardRepo, IOperationService operation)
        {
            cardRepo = _cardRepo;
            operationService = operation;
        }

        public void BlockCard(string numberCard)
        {
            Card card = cardRepo.GetCardByNumber(numberCard);
            numberOfApptems++;
            if(card.CardBanned || numberOfApptems > 4)
            {
                card.CardBanned = true;
                throw new BlockedCardException(numberCard);
            }
        }

        public Card GetCardByNumber(string number)
        {
            Card card = cardRepo.GetCardByNumber(number);
            return card ?? null;
        }

        public bool IsPinCorrect(string pass, string numberCard)
        {
            if (cardRepo.GetCardByNumber(numberCard).Password == pass)
                return true;
            BlockCard(numberCard);
            return false;
        }

        public WidthdrawResult Widthdraw(string numberCard, decimal sum)
        {
            Card card = cardRepo.GetCardByNumber(numberCard);
            if (card.CardBalance > sum)
            {
                card.CardBalance -= sum;
                Option opt = operationService.AddInfoOption(card, sum);
                return new WidthdrawResult { Balance = card.CardBalance, CardNumber = numberCard, Date = opt.DateOperation, Sum = sum }; 
            }
            else
                throw new IncorrectWidthdrawSumException(sum, card.CardBalance);
        }

        public void Balance(string numberCard)
        {
            Card card = cardRepo.GetCardByNumber(numberCard);
            if(card.CardNumb != null)
            {
                Option opt = operationService.AddInfoOption(card, null);
            }
        }
    }
}
