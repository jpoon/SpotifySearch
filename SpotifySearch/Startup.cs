using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(SpotifySearch.Startup))]
namespace SpotifySearch
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
        }
    }
}
