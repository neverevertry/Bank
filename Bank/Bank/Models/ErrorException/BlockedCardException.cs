using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Bank.Models.ErrorException
{
    public class BlockedCardException : Exception
    {
        public BlockedCardException() : base("You card is blocked") {}
    }
}
