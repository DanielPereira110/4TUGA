using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(_4Tuga.Startup))]
namespace _4Tuga
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
