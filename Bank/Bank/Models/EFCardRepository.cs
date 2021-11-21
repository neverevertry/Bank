using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Bank.Models
{
    public class EFCardRepository : ICardRepository
    {
        private ApplicationDbContext context;

        public EFCardRepository(ApplicationDbContext contextdb) => context = contextdb;

        public Card GetCardByNumber(string numb) => context.Cards.FirstOrDefault(x => x.CardNumb == numb);

        public void Update(Card card) => context.Cards.Update(card);
    }
}
