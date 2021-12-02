using Domain.Entities;

namespace Domain.Interface
{
    public interface ICardRepository
    {
        Card GetCardByNumber(string CardNumb);
        void Update(Card card);
    }
}
