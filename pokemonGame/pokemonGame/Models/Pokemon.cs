using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace pokemonGame.Models
{
    public class Pokemon
    {
        public string Name { get; set; }
        public string Sprite { get; set; }
        public int Health { get; set; }
        public int Attack { get; set; }
        public int Defense { get; set; }
    }
}