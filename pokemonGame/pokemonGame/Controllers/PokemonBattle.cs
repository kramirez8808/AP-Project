using Newtonsoft.Json;
using System.Net.Http;
using System.Threading.Tasks;
using pokemonGame.Models;
using System.Web.Mvc;
using System;
using System.Collections.Generic;


namespace PokemonBattle.Controllers
{
    public class PokemonBattle : Controller
    {
       /* private readonly HttpClient _httpClient;

        public BattleController(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }
        public BattleController()
        {
            // Crear el HttpClient directamente
            _httpClient = new HttpClient();
        }
        public async Task<ActionResult> Index()
        {
            // Obtener dos Pokémon aleatorios
            var pokemon1 = await GetRandomPokemon();
            var pokemon2 = await GetRandomPokemon();

            // Crear la batalla entre los dos Pokémon
            //var battleResult = StartBattle(pokemon1, pokemon2);

           //var winner = StartBattle(pokemon1, pokemon2);

            // Pasar la información a la vista
            ViewBag.Pokemon1 = pokemon1;
            ViewBag.Pokemon2 = pokemon2;
            ViewBag.Winner = winner;
           ViewBag.Messages = battleResult.Messages;  // Mensajes de la batalla
            ViewBag.Damage = battleResult.Damage;


            return View();
        }

        private async Task<Pokemon> GetRandomPokemon()
        {
            var randomId = new Random().Next(1, 1000);
            var url = $"https://pokeapi.co/api/v2/pokemon/{randomId}";
            var response = await _httpClient.GetStringAsync(url);
            dynamic pokemonData = JsonConvert.DeserializeObject(response);

            var pokemon = new Pokemon
            {
                Name = pokemonData.name,
                Sprite = pokemonData.sprites.front_default,
                Health = pokemonData.stats[5].base_stat, // HP
                Attack = pokemonData.stats[4].base_stat, // Attack
                Defense = pokemonData.stats[3].base_stat // Defense
            };

            return pokemon;
        }

        private BattleResult StartBattle(Pokemon pokemon1, Pokemon pokemon2)
        {
            var result = new BattleResult();
            result.Messages = new List<string>(); 

            int damage1 = pokemon1.Attack - pokemon2.Defense;
            int damage2 = pokemon2.Attack - pokemon1.Defense;

            result.Messages.Add($"Pokemon 1 attacks Pokemon 2 and deals {damage1} damage!");
            result.Messages.Add($"Pokemon 2 attacks Pokemon 1 and deals {damage2} damage!");

            result.Winner = damage1 > damage2 ? pokemon1.Name : pokemon2.Name;
            result.Damage = Math.Max(damage1, damage2);

            return result;
        }
        public class BattleResult
        {
            public string Winner { get; set; }
            public List<string> Messages { get; set; } // Lista de mensajes de batalla
            public int Damage { get; set; }
        }*/
    }
}
