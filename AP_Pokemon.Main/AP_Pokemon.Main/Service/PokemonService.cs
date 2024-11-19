using AP_Pokemon.Main.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using AP_Pokemon.Main.Service;
using AP_Pokemon.Main.Service.AP_Pokemon.Main.Service;

namespace AP_Pokemon.Main.Service
{
    public class PokemonService : IPokemonService
    {
        private readonly List<Pokemon> _pokemons = new List<Pokemon>
        {
            new Pokemon { PokemonID = 1, Nickname = "Pikachu", Type = "Eléctrico", HP = 100 },
            new Pokemon { PokemonID = 2, Nickname = "Charmander", Type = "Fuego", HP = 80 },
            new Pokemon { PokemonID = 3, Nickname = "Bulbasaur", Type = "Planta", HP = 70 }
        };

        public Pokemon GetPokemonById(int id)
        {
            return _pokemons.FirstOrDefault(p => p.PokemonID == id);
        }

        public IEnumerable<Pokemon> GetAllPokemons()
        {
            return _pokemons;
        }

        public string SimularBatalla(Pokemon pokemon1, Pokemon pokemon2)
        {
            if (pokemon1.HP > pokemon2.HP)
            {
                return $"{pokemon1.Nickname} ha ganado la batalla!";
            }
            else if (pokemon2.HP > pokemon1.HP)
            {
                return $"{pokemon2.Nickname} ha ganado la batalla!";
            }
            else
            {
                return "La batalla terminó en empate.";
            }
        }
    }
}
