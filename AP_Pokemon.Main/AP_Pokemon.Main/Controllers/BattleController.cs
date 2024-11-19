using AP_Pokemon.Main.Models;
using AP_Pokemon.Main.Service;
using System;
using System.Web.Mvc;

namespace AP_Pokemon.Main.Controllers
{
    public class BattleController : Controller
    {
        private readonly PokemonService _pokemonService;

        public BattleController()
        {
            _pokemonService = new PokemonService();   }

        public BattleController(PokemonService pokemonService)
        {
            _pokemonService = pokemonService;
        }

        public ActionResult StartBattle(int? pokemon1Id, int? pokemon2Id)
        {
            if (!pokemon1Id.HasValue || !pokemon2Id.HasValue)
            {
                ViewData["BattleResult"] = "Debe proporcionar ambos IDs de Pokémon.";
                return View(); 
            }

            var pokemon1 = _pokemonService.GetPokemonById(pokemon1Id.Value);
            var pokemon2 = _pokemonService.GetPokemonById(pokemon2Id.Value);

            if (pokemon1 == null || pokemon2 == null)
            {
                ViewData["BattleResult"] = "Uno o ambos Pokémon no existen.";
                return View();
            }

            var result = SimularBatalla(pokemon1, pokemon2);

            ViewData["Pokemon1"] = pokemon1;
            ViewData["Pokemon2"] = pokemon2;
            ViewData["BattleResult"] = result;

            return View();
        }

        private string SimularBatalla(Pokemon pokemon1, Pokemon pokemon2)
        {
            if (pokemon1.HP > pokemon2.HP)
                return $"{pokemon1.Nickname} ha ganado la batalla!";
            else if (pokemon2.HP > pokemon1.HP)
                return $"{pokemon2.Nickname} ha ganado la batalla!";
            else
                return "La batalla terminó en empate.";
        }
    }
}
