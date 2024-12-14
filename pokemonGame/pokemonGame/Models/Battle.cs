using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PokemonGame.Models
{
    public class Battle
    {

        public string User { get; set; }
        public Pokemon Pokemon1 { get; set; }
        public Pokemon Pokemon2 { get; set; }
        public string Title { get; set; }
        public string Message { get; set; }
        public string Status { get; set; }

    }
}
