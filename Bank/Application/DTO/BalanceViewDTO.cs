using System;
using System.Collections.Generic;
using System.Text;

namespace Application.DTO
{
    public class BalanceViewDTO
    {
        public string CardNumber { get; set; }
        public DateTime Date { get; set; }
        public decimal Balance { get; set; }
    }
}
