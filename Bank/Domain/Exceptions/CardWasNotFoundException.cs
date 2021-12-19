using System;

namespace Domain.Exceptions
{
    public class CardWasNotFoundException : Exception
    {
        public CardWasNotFoundException(string massage): base($"Card with № {massage} was not found") {}
    }
}
