using Microsoft.Owin;
using Owin;
using WebLayer;

[assembly: OwinStartup(typeof (Startup))]

namespace WebLayer
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}