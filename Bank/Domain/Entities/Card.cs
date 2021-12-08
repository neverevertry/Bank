using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Domain.Entities
{
    public class Card
    {
        [Key]
        public int CardId { get; set; }
        [Required]
        public string CardNumb { get; set; }
        [Required]
        public string Password { get; set; }
        public bool CardBanned { get; set; }
        [Required]
        public decimal CardBalance { get; set; }
        public ICollection<Option> Options { get; set; }
    }
}
