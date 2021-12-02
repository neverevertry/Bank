using System;

namespace Domain.Exceptions
{
    public class IncorrectWidthdrawSumException : Exception
    {
        public IncorrectWidthdrawSumException(decimal sum, decimal balance) : base($"Widthdraw amount exceeds invoice amout, Widthdraw: {sum}, balance {balance}") { }
    }
}
