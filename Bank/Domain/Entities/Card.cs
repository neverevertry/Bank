using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Domain.Entities
{
    public class Card
    {
        [Key]
        public int CardId { get; set; }
        [Required]
        public string CardNumb { get; set; } // to do : rename to cardnumber
        [Required]
        public string PinHash { get; set; }
        public bool CardBanned { get; set; } // is banned/ is block
        [Required]
        public decimal CardBalance { get; set; }
        public ICollection<Option> Options { get; set; }
    }
}
