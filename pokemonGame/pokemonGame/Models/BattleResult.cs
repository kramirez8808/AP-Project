using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Collections.Generic;


namespace pokemonGame.Models
{
    public class BattleResult
    {
        public string Winner { get; set; }
        public List<string> Messages { get; set; } = new List<string>();
        public int Damage { get; set; }
    }
}