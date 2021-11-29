using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Bank.Models.ErrorException
{
    public class IncorrectPinException : Exception
    {
        public IncorrectPinException() : base("Incorrect password") { }
    }
}
