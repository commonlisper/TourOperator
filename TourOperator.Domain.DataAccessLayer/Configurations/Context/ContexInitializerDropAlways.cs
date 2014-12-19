using System;
using System.Data.Entity;
using TourOperator.Domain.Data.DomainModel;

namespace TourOperator.Domain.DataAccessLayer.Configurations.Context
{
    public class ContexInitializerDropAlways : DropCreateDatabaseAlways<DomainDbContext>
    {
        protected override void Seed(DomainDbContext context)
        {
            base.Seed(context);

            context.Countries.Add(new Country() { Id = Guid.NewGuid(), Name = "Австрия" });
            context.Countries.Add(new Country() { Id = Guid.NewGuid(), Name = "Греция" });
            context.Countries.Add(new Country() { Id = Guid.NewGuid(), Name = "Турция" });

            context.SaveChanges();
        }
    }
}
