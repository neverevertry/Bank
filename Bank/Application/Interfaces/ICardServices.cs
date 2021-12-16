using Application.DTO;
using Domain.Entities;
using System.Threading.Tasks;

namespace Application.Interfaces
{
    public interface ICardServices
    {
        Task<Card> GetCardByNumber(string number);
        void ValidatePin(string pass, Card card);
        ReportDto Widthdraw(Card card, decimal sum);
        BalanceDto Balance(Card card);
    }
}
