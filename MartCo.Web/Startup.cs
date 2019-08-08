using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(MartCo.Web.Startup))]
namespace MartCo.Web
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
