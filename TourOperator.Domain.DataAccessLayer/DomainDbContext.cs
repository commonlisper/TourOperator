using System.Data.Entity;
using System.Text;
using Microsoft.AspNet.Identity.EntityFramework;
using TourOperator.Domain.Data.DomainModel;
using TourOperator.Domain.Data.DomainModel.AuthModel;
using TourOperator.Domain.Data.Entities;
using TourOperator.Domain.DataAccessLayer.Configurations.Entities;

namespace TourOperator.Domain.DataAccessLayer
{
    public class DomainDbContext : IdentityDbContext<ApplicationUser>
    {
        public DomainDbContext()
            : base("DomainModel", throwIfV1Schema: false)
        {
            Configuration.LazyLoadingEnabled = false;
        }

        public static DomainDbContext Create()
        {
            return new DomainDbContext();
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Configurations.Add(new CountryConfiguration());
            modelBuilder.Configurations.Add(new HealthResortConfiguration());
            modelBuilder.Configurations.Add(new HotelConfiguration());
            modelBuilder.Configurations.Add(new TourConfiguration());
        }

        public virtual DbSet<Country> Countries { get; set; }
        public virtual DbSet<Tour> Tours { get; set; }
        public virtual DbSet<HealthResort> HealthResorts { get; set; }
        public virtual DbSet<Hotel> Hotels { get; set; }
    }
}