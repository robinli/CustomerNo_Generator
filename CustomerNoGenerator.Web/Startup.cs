using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(CustomerNoGenerator.Web.Startup))]
namespace CustomerNoGenerator.Web
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
