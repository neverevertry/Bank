using System;

namespace Application.DTO
{
    public class WidthdrawResult
    {
        public string CardNumber { get; set; }
        public DateTime Date { get; set; }
        public decimal Sum { get; set; }
        public decimal Balance { get; set; }
    }
}
