using System;
using System.Collections.Generic;
using System.Data.Entity;
using TourOperator.Domain.Data.DomainModel;
using TourOperator.Domain.Data.DomainModel.Enums;
using TourOperator.Domain.Data.Entities;

namespace TourOperator.Domain.DataAccessLayer.Configurations.Context
{
    public class ContexInitializerDropAlways : DropCreateDatabaseAlways<DomainDbContext>
    {
        protected override void Seed(DomainDbContext context)
        {
            base.Seed(context);

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

            List<Tour> tours = new List<Tour>
            {
                new Tour
                {
                    Price = 800,
                    Nights = 15
                },
                new Tour
                {
                    Price = 650,
                    Nights = 10
                },
                new Tour
                {
                    Price = 350,
                    Nights = 5
                }
            };

            List<HealthResort> healthResorts = new List<HealthResort>
            {
                new HealthResort
                {
                    Name = "Цель Ам Зее"
                },
                new HealthResort
                {
                    Name = "Капрун"
                },
                new HealthResort
                {
                    Name = "Бад Хофгаштайн"
                }                
            };

            List<Hotel> hotels = new List<Hotel>
            {
                new Hotel
                {
                    Name = "PENSION HOCHWIMMER",
                    TypeOfFood = TypeOfFoodEnum.BB,
                    Category = 4
                },
                new Hotel
                {
                    Name = "HUBERTUSHOF HOTEL",
                    TypeOfFood = TypeOfFoodEnum.BB,
                    Category = 3
                },
                new Hotel
                {
                    Name = "ANTONIUS HOTEL",
                    TypeOfFood = TypeOfFoodEnum.BB,
                    Category = 4
                }
            };

            countries[0].Tours.Add(tours[0]);
            countries[1].Tours.Add(tours[1]);
            countries[2].Tours.Add(tours[2]);

            healthResorts[0].Tour = tours[0];
            healthResorts[0].Hotel = hotels[0];

            healthResorts[1].Tour = tours[1];
            healthResorts[1].Hotel = hotels[1];

            healthResorts[2].Tour = tours[2];
            healthResorts[2].Hotel = hotels[2];

            context.Countries.AddRange(countries);
            context.HealthResorts.AddRange(healthResorts);
            context.SaveChanges();       
        }
    }
}
