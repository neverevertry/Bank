using Domain.Entities;
using System.Threading.Tasks;

namespace Domain.Interface
{
    public interface ICardRepository
    {
        Task<Card> GetCardByNumber(string CardNumb);
        Task Update(Card card);
    }
}
