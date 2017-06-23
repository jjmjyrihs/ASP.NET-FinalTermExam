using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(ASP.MVC.Startup))]
namespace ASP.MVC
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
