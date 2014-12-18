using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using TourOperator.Domain.DataAccessLayer;

namespace TourOperator.Web
{
    public partial class Startup
    {
        public void ConfigureDatabase()
        {
            // TODO: change in production!
            Database.SetInitializer(new DropCreateDatabaseAlways<DomainDbContext>());
        }
    }
}