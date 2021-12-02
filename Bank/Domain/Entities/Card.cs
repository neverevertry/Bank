using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Domain.Entities
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
        [Required(ErrorMessage = "test")]
        public decimal CardBalance { get; set; }
        public ICollection<Option> Options { get; set; }
    }
}
