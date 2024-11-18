using AP_Pokemon.Main.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace AP_Pokemon.Main.Repository
{
    public class PokemonRepository : RepositoryBase<Pokemon>
    {
        public PokemonRepository(DbContext context) : base(context)
        {
        }
    }
}