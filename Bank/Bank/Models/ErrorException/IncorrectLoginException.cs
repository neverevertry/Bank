using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Bank.Models.ErrorException
{
    public class IncorrectLoginException : Exception
    {
        public IncorrectLoginException(): base("Incorrect login") {}
    }
}
