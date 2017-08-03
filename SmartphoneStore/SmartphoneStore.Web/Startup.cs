using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(SmartphoneStore.Web.Startup))]
namespace SmartphoneStore.Web
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
