using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(AP_Pokemon.Main.Startup))]
namespace AP_Pokemon.Main
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
