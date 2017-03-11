using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Wanderlust.WebClient.Startup))]
namespace Wanderlust.WebClient
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
