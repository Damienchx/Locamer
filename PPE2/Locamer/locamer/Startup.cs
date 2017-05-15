using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(locamer.Startup))]
namespace locamer
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
