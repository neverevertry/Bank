using System;

namespace Domain.Exceptions
{
    public class IncorrectLoginException : Exception
    {
        public IncorrectLoginException(string massage): base($"Incorrect login: {massage}") {}
    }
}
