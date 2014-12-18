using TourOperator.Domain.DomainModel;

namespace TourOperator.Domain
{
    using System;
    using System.Data.Entity;
    using System.Linq;

    public class DomainModelContext : DbContext
    {
        // Your context has been configured to use a 'DomainModel' connection string from your application's 
        // configuration file (App.config or Web.config). By default, this connection string targets the 
        // 'TourOperator.Domain.DomainModel' database on your LocalDb instance. 
        // 
        // If you wish to target a different database and/or database provider, modify the 'DomainModel' 
        // connection string in the application configuration file.
        public DomainModelContext()
            : base("name=DomainModel")
        {
        }

        // Add a DbSet for each entity type that you want to include in your model. For more information 
        // on configuring and using a Code First model, see http://go.microsoft.com/fwlink/?LinkId=390109.

        // public virtual DbSet<MyEntity> MyEntities { get; set; }
        public virtual DbSet<Country> Countries { get; set; }
        public virtual DbSet<Tour> Tours { get; set; }
        public virtual DbSet<HealthResort> HealthResorts { get; set; }
        public virtual DbSet<Hotel> Hotels { get; set; }
    }

    //public class MyEntity
    //{
    //    public int Id { get; set; }
    //    public string Name { get; set; }
    //}
}