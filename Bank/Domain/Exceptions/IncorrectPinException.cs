using System;

namespace Domain.Exceptions
{
    public class IncorrectPinException : Exception
    {
        public IncorrectPinException() : base("Incorrect password") { }
    }
}
