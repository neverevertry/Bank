using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Bank.Models.ViewModels
{
    public class ReportViewModel
    {
        public string CardNumb { get; set; }
        public DateTime DateTime { get; set; }
        public decimal Widthdraw { get; set; }
        public decimal Balance { get; set; }
    }
}
