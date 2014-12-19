using System;
using System.Data.Entity;
using TourOperator.Domain.Data.DomainModel;

namespace TourOperator.Domain.DataAccessLayer.Configurations.Context
{
    public class ContextInitializerDropIfChanged : DropCreateDatabaseIfModelChanges<DomainDbContext>
    {
        protected override void Seed(DomainDbContext context)
        {
            base.Seed(context);

            context.Countries.Add(new Country() { Id = Guid.NewGuid(), Name = "�������" });
            context.Countries.Add(new Country() { Id = Guid.NewGuid(), Name = "������" });
            context.Countries.Add(new Country() { Id = Guid.NewGuid(), Name = "������" });

            context.SaveChanges();
        }
    }
}