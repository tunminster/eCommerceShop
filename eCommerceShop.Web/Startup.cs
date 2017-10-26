using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(eCommerceShop.Web.Startup))]
namespace eCommerceShop.Web
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
