using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Bank.Models
{
    public class Option
    {
        [Key]
        public int Id { get; set; }
        public Card Card { get; set; }
        public int CardId { get; set; }
        public DateTime DateOperation { get; set; }
        public decimal Widthdraw { get; set; }
        public OptionDescription OptionsDesc { get; set; }
        public int OptionDescriptionId { get; set; }
    }
}
