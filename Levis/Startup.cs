using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Levis.Startup))]
namespace Levis
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
