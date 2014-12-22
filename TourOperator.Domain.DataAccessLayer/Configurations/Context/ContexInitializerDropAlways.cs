using System;
using System.Collections.Generic;
using System.Data.Entity;
using TourOperator.Domain.Data.DomainModel;
using TourOperator.Domain.Data.Entities;

namespace TourOperator.Domain.DataAccessLayer.Configurations.Context
{
    public class ContexInitializerDropAlways : DropCreateDatabaseAlways<DomainDbContext>
    {
        protected override void Seed(DomainDbContext context)
        {
            base.Seed(context);

            List<Tour> tours = new List<Tour>
            {
                new Tour
                {
                    Price = 800.00m,
                    StartedOn = DateTime.Now,
                    EndedOn = DateTime.Now.AddMonths(1),
                    Nights = 15
                },
                new Tour
                {
                    Price = 650.00m,
                    StartedOn = DateTime.Now.AddDays(10),
                    EndedOn = DateTime.Now.AddMonths(2),
                    Nights = 10
                },
                new Tour
                {
                    Price = 350m,
                    StartedOn = DateTime.Now.AddDays(5),
                    EndedOn = DateTime.Now.AddDays(5),
                    Nights = 5
                }
            };

            List<Country> countries = new List<Country>
            {
                new Country
                {  
                    Name = "Австрия"
                },
                new Country
                {
                    Name = "Греция"
                },
                new Country
                {
                    Name = "Турция"
                }
            };

            countries[0].Tours.Add(tours[0]);
            countries[1].Tours.Add(tours[1]);
            countries[2].Tours.Add(tours[2]);

            context.Countries.AddRange(countries);            
            context.SaveChanges();            
        }
    }
}
