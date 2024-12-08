using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using AP_Pokemon.Main.Services;
using AP_Pokemon.Main.Models;

namespace AP_Pokemon.Main.Services
{

    public interface IPokemonService
    {
        //Pokemon buildPokemon(string name);

        Task<Pokemon> buildPokemonAsync(string name);

        Task<List<Pokemon>> buildAllPokemons(string[] pokemonNames);

    }


}