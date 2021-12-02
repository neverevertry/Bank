using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Bank.Models.ViewModels
{
    public class BalanceViewModel
    {
        public string CardNumb { get; set; }
        public DateTime DateTime { get; set; }
        public decimal Balance { get; set; }
    }
}
