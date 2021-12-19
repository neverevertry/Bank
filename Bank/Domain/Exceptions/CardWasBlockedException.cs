using System;

namespace Domain.Exceptions
{
    public class CardWasBlockedException : Exception
    {
        public CardWasBlockedException(string cardNumber) : base($"№{cardNumber} was blocked") {}
    }
}
