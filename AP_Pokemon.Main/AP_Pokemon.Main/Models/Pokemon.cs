using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace AP_Pokemon.Main.Models
{
    public class Pokemon
    {
        [Key]
        public int PokemonID { get; set; }

        [Required]
        public string Nickname { get; set; }

        public int HP { get; set; }
        public int Attack { get; set; }

        [Required]
        [StringLength(50)]
        public string Type { get; set; }

        [Required]
        [StringLength(100)]
        public string Species { get; set; }

    }
}