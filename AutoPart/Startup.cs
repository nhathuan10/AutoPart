using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(AutoPart.Startup))]
namespace AutoPart
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
