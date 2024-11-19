using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AP_Pokemon.Main.Service; 

namespace AP_Pokemon.Main.Service
{
    namespace AP_Pokemon.Main.Service
    {
        public interface IPokemonService
        {
            Pokemon GetPokemonById(int id);

            IEnumerable<Pokemon> GetAllPokemons();  

            string SimularBatalla(Pokemon pokemon1, Pokemon pokemon2);
        }
    }


}