using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(WebApplication14.Startup))]
namespace WebApplication14
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
