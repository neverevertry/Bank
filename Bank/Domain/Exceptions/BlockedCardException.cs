using System;

namespace Domain.Exceptions
{
    public class BlockedCardException : Exception
    {
        public BlockedCardException(string cardNumber) : base($"{cardNumber} is blocked") {}
    }
}
