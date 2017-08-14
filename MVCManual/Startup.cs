using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(MVCManual.Startup))]
namespace MVCManual
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
