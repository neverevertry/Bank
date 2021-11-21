using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Bank.Models
{
    public class Card
    {
        [Key]
        public int CardId { get; set; }
        [Required(ErrorMessage ="Input Numb card")]
        public string CardNumb { get; set; }
        [Required(ErrorMessage = "Input password")]
        public string Password { get; set; }
        public bool CardBanned { get; set; }
        public decimal CardBalance { get; set; }
        public ICollection<Option> Options { get; set; }
    }
}
