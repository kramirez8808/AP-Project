using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using System.Web;

namespace pokemonGame.Models
{  
        public class PokemonApiResponse
        {
            [JsonPropertyName("count")]
            public int Count { get; set; }

            [JsonPropertyName("next")]
            public string Next { get; set; }

            [JsonPropertyName("previous")]
            public string Previous { get; set; }

            [JsonPropertyName("results")]
            public List<Pokemon> Results { get; set; }
        }
    }
