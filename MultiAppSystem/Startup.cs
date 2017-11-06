using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(MultiAppSystem.Startup))]
namespace MultiAppSystem
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
