using System.Data.Entity;
using TourOperator.Domain.DataAccessLayer.Configurations.Context;

namespace TourOperator.Web
{
    public partial class Startup
    {
        public void ConfigureDatabase()
        {
            // TODO: change in production!
            //Database.SetInitializer(new ContexInitializerDropAlways());
            //Database.SetInitializer(new ContextInitializerDropIfChanged());
        }
    }
}