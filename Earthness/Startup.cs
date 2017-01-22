using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Earthness.Startup))]
namespace Earthness
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
