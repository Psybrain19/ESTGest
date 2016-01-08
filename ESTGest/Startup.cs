using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(ESTGest.Startup))]
namespace ESTGest
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
