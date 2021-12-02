using Domain.Entities;
using Domain.Interface;
using System.Linq;

namespace DataAccess.Contexts
{
    public class EFCardRepository : ICardRepository
    {
        private ApplicationDbContext context;

        public EFCardRepository(ApplicationDbContext contextdb) => context = contextdb;

        public Card GetCardByNumber(string numb) => context.Cards.FirstOrDefault(x => x.CardNumb == numb);

        public void Update(Card card) => context.Cards.Update(card);
    }
}
