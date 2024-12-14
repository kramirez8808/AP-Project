using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(PokemonGame.Startup))]
namespace PokemonGame
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
