using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Energieweb.Startup))]
namespace Energieweb
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
