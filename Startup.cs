using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(ChineseBridge.Startup))]
namespace ChineseBridge
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
