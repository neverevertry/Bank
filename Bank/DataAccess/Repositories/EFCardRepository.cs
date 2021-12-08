using Domain.Entities;
using Domain.Interface;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace DataAccess.Contexts
{
    public class EFCardRepository : ICardRepository
    {
        private ApplicationDbContext context;

        public EFCardRepository(ApplicationDbContext contextdb) => context = contextdb;

        public async Task<Card> GetCardByNumber(string numb) => await context.Cards.FirstOrDefaultAsync(x => x.CardNumb == numb);

        public async Task Update(Card card)
        {
            context.Cards.Update(card);
            await context.SaveChangesAsync();
        }
    }
}
