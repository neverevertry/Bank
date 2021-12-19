using System;

namespace Domain.Exceptions
{
    public class IncorrectWidthdrawAmountException : Exception
    {
        public IncorrectWidthdrawAmountException(decimal sum, decimal balance) : base($"Widthdraw amount exceeds invoice amout, Widthdraw: {sum}, balance {balance}") { }
    }
}
