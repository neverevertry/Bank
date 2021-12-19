using Domain.Entities;
using Domain.Interface;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace DataAccess.Contexts
{
    public class EFCardRepository : ICardRepository
    {
        private ApplicationDbContext context;

        public EFCardRepository(ApplicationDbContext contextdb) => context = contextdb;

        public async Task<Card> GetCardByNumber(string numb) => await context.Cards
                                                                             .AsNoTracking()
                                                                             .SingleOrDefaultAsync(x => x.CardNumb == numb);

        public void Update(Card card)
        {
            context.Cards.Update(card);
        }
    }
}
