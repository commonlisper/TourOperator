using System.Data.Entity;
using Microsoft.Owin;
using Owin;
using TourOperator.Domain.DataAccessLayer;

[assembly: OwinStartupAttribute(typeof(TourOperator.Web.Startup))]
namespace TourOperator.Web
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
            ConfigureDatabase();            
        }
    }
}
