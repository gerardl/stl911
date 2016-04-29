using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Stl911.Startup))]
namespace Stl911
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
