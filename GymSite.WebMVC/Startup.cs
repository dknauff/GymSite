using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(GymSite.WebMVC.Startup))]
namespace GymSite.WebMVC
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }


    }
}
