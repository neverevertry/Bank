using Application.DTO;
using Application.Interfaces;
using Domain.Entities;
using Domain.Exceptions;
using Domain.Interface;
using System;
using System.Threading.Tasks;

namespace Application
{
    public class CardService : ICardServices
    {
        private readonly ICardRepository cardRepo;
        private readonly IOptionService operationService;
        private static int numberOfApptems = 0;
        public CardService(ICardRepository _cardRepo, IOptionService operation)
        {
            cardRepo = _cardRepo;
            operationService = operation;
        }

        private void BlockCard(Card card)
        {
            numberOfApptems++;
            if(card.CardBanned || numberOfApptems > 4)
            {
                card.CardBanned = true;
                throw new BlockedCardException(card.CardNumb);
            }
        }

        public async Task<Card> GetCardByNumber(string number)
        {
            Card card = await cardRepo.GetCardByNumber(number);
            return card ?? null;
        }

        public bool IsPinCorrect(string pass, Card card)
        {
            if (card.Password == pass)
                return true;
            BlockCard(card);
            return false;
        }

        public WidthdrawViewDTO Widthdraw(Card card, decimal sum)
        {
            if (card.CardBalance < sum)
                throw new IncorrectWidthdrawSumException(sum, card.CardBalance);

            card.CardBalance -= sum;
            Option opt = operationService.AddInfoOption(card, sum);
            return new WidthdrawViewDTO { Balance = card.CardBalance, CardNumber = card.CardNumb, Date = opt.DateOperation, Sum = sum }; 
          
        }

        public BalanceViewDTO Balance(Card card)
        {
            if(card.CardNumb != null)
            {
                operationService.AddInfoOption(card, null);
                return new BalanceViewDTO { Balance = card.CardBalance, CardNumber = card.CardNumb, Date = DateTime.Now };
            }
            return null;
        }
    }
}
