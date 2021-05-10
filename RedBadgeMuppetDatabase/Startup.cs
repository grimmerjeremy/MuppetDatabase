using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(RedBadgeMuppetDatabase.Startup))]
namespace RedBadgeMuppetDatabase
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
