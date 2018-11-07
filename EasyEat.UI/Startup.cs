using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(EasyEat.UI.Startup))]
namespace EasyEat.UI
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
