using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Bank.Models
{
    public static class CardBlocked
    {
        private static int numberOfApptems = 0;

        public static bool BlockAFaildAttemp(Card card)
        {
            numberOfApptems++;
            if(!card.CardBanned && numberOfApptems == 4)
            {
                CardBlock(card);
                return false;
            }
            return true;
        }

        private static void CardBlock(Card card) => card.CardBanned = true;
    }
}
