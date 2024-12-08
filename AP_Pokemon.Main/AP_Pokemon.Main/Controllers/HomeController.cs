using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AP_Pokemon.Main.Services;
using AP_Pokemon.Main.Models;
using System.Threading.Tasks;

namespace AP_Pokemon.Main.Controllers
{
    public class HomeController : Controller
    {
        //public ActionResult Index()
        //{
        //    PokemonService pokemonService = new PokemonService();
        //    string[] pokemonNames = { "ditto", "pikachu", "charizard" };

        //    List<Pokemon> pokemonList = pokemonService.buildAllPokemons(pokemonNames);

        //    foreach (Pokemon pokemon in pokemonList) 
        //    {
        //        System.Diagnostics.Debug.WriteLine(pokemon.Name);
        //    }

        //    return View();
        //}

        public async Task<ActionResult> Index()
        {
            PokemonService pokemonService = new PokemonService();
            string[] pokemonNames = { "ditto", "pikachu", "charizard" };

            // Await the asynchronous call to build all pokemons
            List<Pokemon> pokemonList = await pokemonService.buildAllPokemons(pokemonNames);

            //foreach (Pokemon pokemon in pokemonList)
            //{
            //    System.Diagnostics.Debug.WriteLine(pokemon.Name);
            //    System.Diagnostics.Debug.WriteLine(pokemon.Moves.ToString());
            //    System.Diagnostics.Debug.WriteLine(pokemon.Types.ToString());
            //    System.Diagnostics.Debug.WriteLine(pokemon.Stats.ToString());
            //    System.Diagnostics.Debug.WriteLine(pokemon.ImageURL);

            //}

            foreach (Pokemon pokemon in pokemonList)
            {
                // Print the Pokemon name
                System.Diagnostics.Debug.WriteLine(pokemon.Name);

                // Print Moves (as a list of names and their corresponding values)
                foreach (var move in pokemon.Moves)
                {
                    System.Diagnostics.Debug.WriteLine($"Move: {move.Key}, Value: {move.Value}");
                }

                // Print Types (as a list of type names)
                System.Diagnostics.Debug.WriteLine("Types:");
                foreach (var type in pokemon.Types)
                {
                    System.Diagnostics.Debug.WriteLine(type);
                }

                // Print Stats (as a list of stat names and their corresponding base_stat)
                foreach (var stat in pokemon.Stats)
                {
                    System.Diagnostics.Debug.WriteLine($"Stat: {stat.Key}, Base Stat: {stat.Value}");
                }

                // Print the Image URL
                System.Diagnostics.Debug.WriteLine(pokemon.ImageURL);
            }


            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}