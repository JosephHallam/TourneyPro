using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(TourneyPro.Startup))]
namespace TourneyPro
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
