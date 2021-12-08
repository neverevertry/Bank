using Application.DTO;
using Domain.Entities;
using System.Threading.Tasks;

namespace Application.Interfaces
{
    public interface ICardServices
    {
        Task<Card> GetCardByNumber(string number);
        bool IsPinCorrect(string pass, Card card);
        WidthdrawViewDTO Widthdraw(Card card, decimal sum);
        BalanceViewDTO Balance(Card card);
    }
}
