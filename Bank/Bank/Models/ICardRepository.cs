using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Bank.Models
{
    public interface ICardRepository
    {
        Card GetCardByNumber(string CardNumb);
        void Update(Card card);
    }
}
