using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace AP_Pokemon.Main.Models
{
    public class Pokemon
    {
        public string Name { get; set; }

        public Dictionary<string, int> Moves { get; set; }
        // { "Move1" : 20 }

        public string[] Types { get; set; }
        // ["Fire", "Normal"]

        public Dictionary<string, int> Stats { get; set; }
        // { "HP" : 20 }

        public string ImageURL { get; set; }

    }
}