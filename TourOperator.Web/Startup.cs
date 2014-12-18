using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(TourOperator.Web.Startup))]
namespace TourOperator.Web
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
