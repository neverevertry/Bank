using System;
using System.ComponentModel.DataAnnotations;

namespace Domain.Entities
{
    public class Option
    {
        [Key]
        public int Id { get; set; }
        public Card Card { get; set; }
        public int CardId { get; set; }
        public DateTime DateOperation { get; set; }
        public decimal? Widthdraw { get; set; } // wid -> withdraw
        public OptionDescription OptionsDesc { get; set; } // type// description
        public int OptionDescriptionId { get; set; }
    }
}
