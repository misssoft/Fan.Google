using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(SearchConsole.Startup))]
namespace SearchConsole
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
