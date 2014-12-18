using System.Data.Entity;
using Microsoft.AspNet.Identity.EntityFramework;
using TourOperator.Domain.Data.DomainModel;
using TourOperator.Domain.Data.DomainModel.AuthModel;

namespace TourOperator.Domain.DataAccessLayer
{
    public class DomainDbContext : IdentityDbContext<ApplicationUser>
    {
        public DomainDbContext()
            : base("DomainModel", throwIfV1Schema: false)
        {
        }

        public static DomainDbContext Create()
        {
            return new DomainDbContext();
        }

        public virtual DbSet<Country> Countries { get; set; }
        public virtual DbSet<Tour> Tours { get; set; }
        public virtual DbSet<HealthResort> HealthResorts { get; set; }
        public virtual DbSet<Hotel> Hotels { get; set; }
    }
}