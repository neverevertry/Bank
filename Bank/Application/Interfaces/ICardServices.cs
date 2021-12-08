using Application.DTO;
using Domain.Entities;

namespace Application.Interfaces
{
    public interface ICardServices
    {
        Card GetCardByNumber(string number);
        bool IsPinCorrect(string pass, Card card);
        WidthdrawViewDTO Widthdraw(Card card, decimal sum);
        private void BlockCard(Card card) { }
        BalanceViewDTO Balance(Card card);
    }
}
