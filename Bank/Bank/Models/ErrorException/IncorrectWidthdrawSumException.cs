using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Bank.Models.ErrorException
{
    public class IncorrectWidthdrawSumException : Exception
    {
        public IncorrectWidthdrawSumException() : base("Widthdraw amount exceeds invoice amout") { }
    }
}
