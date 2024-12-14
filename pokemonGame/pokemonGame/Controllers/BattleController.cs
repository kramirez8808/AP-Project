using Newtonsoft.Json;
using PokemonGame.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using static PokemonGame.Models.BattleMessages;

namespace PokemonGame.Controllers
{
    [Authorize]
    public class BattleController : Controller
    {
        // GET: Battle
        public async Task<ActionResult> Index()
        {
            var pokemons = await PickPokemons();
            var model = new Battle();
            model.Title = BattleMessages.TITLE;
            model.User = HttpContext.User.Identity.Name;
            model.Pokemon1 = pokemons.Item1;
            model.Pokemon2 = pokemons.Item2;
            model.Status = "Start Battle!";
            return View(model);
        }

        [HttpPost]
        public JsonResult StartBattle(Battle battle)
        {
            var variables = new Dictionary<string, string>
            {
                { "attacker", battle.Pokemon1.Name },
            };

            var pk1 = battle.Pokemon1;
            var pk2 = battle.Pokemon2;

            if (pk1.Health < 10 || pk2.Health < 10)
            {
                var winner = pk1.Health > pk2.Health ? pk1.Name : pk2.Name;
                battle.Message = $"The Winner is {winner}";
                battle.Status = "Battle is over!";
            }
            else
            {
                Fight(pk1, pk2);
                battle.Message = GetRandomMessage(MessageKey.STRIKE, variables);
                battle.Status = "Next Turn!";
            }
            return Json(battle);
        }

        private Pokemon Fight(Pokemon pokemon1, Pokemon pokemon2)
        {
            var current = GetRandom(1, 2);
            if (pokemon1.Health > 0 || pokemon2.Health > 0)
            {
                var applyDefense = GetRandom(1, 5);
                if (current == 1)
                {
                    pokemon2.Health -= (applyDefense == 3)
                        ? pokemon1.Attack - pokemon2.Defense
                        : pokemon1.Attack;
                }
                if (current == 2)
                {
                    pokemon1.Health -= (applyDefense == 3)
                        ? pokemon2.Attack - pokemon1.Defense
                        : pokemon2.Attack;
                }
            }

            return current == 1 ? pokemon1 : pokemon2;
        }

        private async Task<Tuple<Pokemon, Pokemon>> PickPokemons()
        {
            var pokemon1 = await GetRandomPokemon();
            var pokemon2 = await GetRandomPokemon();
            return Tuple.Create(pokemon1, pokemon2);
        }
        private async Task<Pokemon> GetRandomPokemon()
        {
            var client = new HttpClient();
            var randomId = new Random().Next(1, 1000);
            var url = $"https://pokeapi.co/api/v2/pokemon/{randomId}";
            var response = await client.GetStringAsync(url);
            dynamic pokemonData = JsonConvert.DeserializeObject(response);
            var pokemonDataVar = JsonConvert.DeserializeObject(response);

            var pokemon = new Pokemon
            {
                Name = pokemonData.name,
                Sprite = pokemonData.sprites.front_default,
                Health = (int) pokemonData.stats[0].base_stat, // HP
                Attack = (int)pokemonData.stats[1].base_stat, // Attack
                Defense = (int)pokemonData.stats[2].base_stat // Defense
            };


            return pokemon;
        }

        private int GetRandom(int i, int f) => new Random().Next(i, f);
    }

}
