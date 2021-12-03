using Application.DTO;
using Domain.Entities;

namespace Application.Interfaces
{
    public interface ICardServices
    {
        Card GetCardByNumber(string number);
        bool IsPinCorrect(string pass, string numberCard);
        WidthdrawResult Widthdraw(string numberCard, decimal sum);
        void BlockCard(string numberCard);
        void Balance(string numberCard);
    }
}
