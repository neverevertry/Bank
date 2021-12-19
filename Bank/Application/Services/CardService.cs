using Application.DTO;
using Application.Interfaces;
using Application.Security;
using DataAccess.UnitOfWork;
using Domain.Entities;
using Domain.Exceptions;
using Domain.Interface;
using System.Threading.Tasks;

namespace Application
{
    public class CardService : ICardServices
    {
        private readonly ICardRepository _cardRepository;
        private readonly IOptionService _operationService;
        private readonly ITimeProvider _timeProvider;

        private static int numberOfApptems = 0;

        public CardService(ICardRepository cardRepository, IOptionService operation, ITimeProvider timeProvider)
        {
            _cardRepository = cardRepository;
            _operationService = operation;
            _timeProvider = timeProvider;
        }
        public async Task<Card> GetCardByNumber(string number)
        {
            Card card = await _cardRepository.GetCardByNumber(number);
            if(card == null)
                throw new CardWasNotFoundException(number);

            if (card.CardBanned)
                throw new CardWasBlockedException(number);

            return card;
        }

        public void ValidatePin(string pass, Card card)
        {
            if (PasswordHasher.VerifyHash(pass, card.PinHash))
                 return;

            numberOfApptems++;

            if (numberOfApptems == 4)
            {
                card.CardBanned = true;
                _cardRepository.Update(card);
                throw new CardWasBlockedException(card.CardNumb);
            }
            throw new IncorrectPinException();
        }

        public ReportDto Widthdraw(Card card, decimal sum)
        {
            if (card.CardBalance <= sum)
                throw new IncorrectWidthdrawAmountException(sum, card.CardBalance);

            card.CardBalance -= sum;
            _cardRepository.Update(card);
            Option opt = _operationService.Log(card.CardId, sum, 1);
            return new ReportDto { Balance = card.CardBalance, CardNumber = card.CardNumb, Date = opt.DateOperation.ToString(), Sum = sum }; 
        }

        public BalanceDto Balance(Card card)
        { 
            _operationService.Log(card.CardId, null, 2);
            return new BalanceDto { Balance = card.CardBalance, CardNumber = card.CardNumb, Date = _timeProvider.Now };
        }
    }
}
