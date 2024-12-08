using AP_Pokemon.Main.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using AP_Pokemon.Main.Services;
using System.Threading.Tasks;
using System.Net.Http;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace AP_Pokemon.Main.Services
{
    public class PokemonService : IPokemonService
    {
        //private readonly List<Pokemon> _pokemons = new List<Pokemon>
        //{
        //    new Pokemon { PokemonID = 1, Nickname = "Pikachu", Type = "Eléctrico", HP = 100 },
        //    new Pokemon { PokemonID = 2, Nickname = "Charmander", Type = "Fuego", HP = 80 },
        //    new Pokemon { PokemonID = 3, Nickname = "Bulbasaur", Type = "Planta", HP = 70 }
        //};

        //public Pokemon GetPokemonById(int id)
        //{
        //    return _pokemons.FirstOrDefault(p => p.PokemonID == id);
        //}

        //public IEnumerable<Pokemon> GetAllPokemons()
        //{
        //    return _pokemons;
        //}

        //public string SimularBatalla(Pokemon pokemon1, Pokemon pokemon2)
        //{
        //    if (pokemon1.HP > pokemon2.HP)
        //    {
        //        return $"{pokemon1.Nickname} ha ganado la batalla!";
        //    }
        //    else if (pokemon2.HP > pokemon1.HP)
        //    {
        //        return $"{pokemon2.Nickname} ha ganado la batalla!";
        //    }
        //    else
        //    {
        //        return "La batalla terminó en empate.";
        //    }
        //}

        //Pokemon buildPokemon(string name) 
        //{
        //    string apiURL = "$https://pokeapi.co/api/v2/pokemon/{name}";
        //    // URL: https://pokeapi.co/api/v2/pokemon/ditto

        //    using (HttpClient client = new HttpClient())
        //    {
        //        try
        //        {
        //            HttpResponseMessage response = await client.GetAsync(apiURL);


        //        }
        //        catch (Exception)
        //        {

        //            throw;
        //        }
        //    }

        //        return null;
        //}

        public async Task<Pokemon> buildPokemonAsync(string name) 
        {
            string apiURL = $"https://pokeapi.co/api/v2/pokemon/{name}";
            // URL: https://pokeapi.co/api/v2/pokemon/ditto

            using (HttpClient client = new HttpClient())
            {
                try
                {
                    HttpResponseMessage response = await client.GetAsync(apiURL);

                    if (response.IsSuccessStatusCode)
                    {
                        string jsonResponse = await response.Content.ReadAsStringAsync();

                        // dynamic rawPokemonData = JsonConvert.DeserializeObject<List<dynamic>>(jsonResponse);
                        JObject json = JObject.Parse(jsonResponse);

                        //return new Pokemon
                        //{
                        //    Name = (string)rawPokemonData.name,
                        //    Moves = null,
                        //    Types = ((IEnumerable<dynamic>)rawPokemonData.types)
                        //            .Select(type => (string)type.type.name)
                        //            .ToArray(),
                        //    Stats = ((IEnumerable<dynamic>)rawPokemonData.stats)
                        //        .ToDictionary(
                        //            stat => (string)stat.stat.name,
                        //            stat => (int)stat.base_stat
                        //        ),
                        //    ImageURL = (string)rawPokemonData.sprites.front_default
                        //};

                        Pokemon pokemon = new Pokemon
                        {
                            Name = json["name"].ToString(),
                            Moves = json["moves"]
                                .ToDictionary(
                                    move => move["move"]["name"].ToString(),
                                    move => 0
                                ),
                            Stats = json["stats"]
                                .ToDictionary(
                                    stat => stat["stat"]["name"].ToString(),
                                    stat => (int)stat["base_stat"]
                                ),
                            Types = json["types"].Select(t => t["type"]["name"].ToString()).ToArray(),
                            ImageURL = json["sprites"]["front_default"].ToString()
                        };

                        return pokemon;

                    }
                    else
                    {
                        return null;
                    }


                }
                catch (Exception)
                {
                    throw;
                }
            }
        }

        public async Task<List<Pokemon>> buildAllPokemons(string[] pokemonNames)
        {

            List<Pokemon> pokemons = new List<Pokemon>();

            foreach (string name in pokemonNames) 
            {
                pokemons.Add(await buildPokemonAsync(name));
            }

            return pokemons;
        }

    }
}
