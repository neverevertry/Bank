using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Bank.Models
{
    public class OptionDescription
    {
        [Key]
        public int OptionDescriptionId { get; set; }
        public string Descrtiptions { get; set; }
        public ICollection<Option> Options { get; set; }
    }
}
