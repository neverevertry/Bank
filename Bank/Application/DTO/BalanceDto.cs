using System;

namespace Application.DTO
{
    public class BalanceDto
    {
        public string CardNumber { get; set; }
        public DateTime Date { get; set; }
        public decimal Balance { get; set; }
    }
}
