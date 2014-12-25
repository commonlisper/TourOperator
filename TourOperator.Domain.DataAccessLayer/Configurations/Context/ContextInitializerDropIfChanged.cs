using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using TourOperator.Domain.Data.Entities;

namespace TourOperator.Domain.DataAccessLayer.Configurations.Context
{
    public class ContextInitializerDropIfChanged : DropCreateDatabaseIfModelChanges<DomainDbContext>
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

            List<TypeOfFood> typeOfFoods = new List<TypeOfFood>
            {
                new TypeOfFood
                {
                    Title = "BB",
                    Description = "qwerty",                  
                },
                new TypeOfFood
                {
                    Title = "FB",
                    Description = "qwerty",
                },
                new TypeOfFood
                {
                    Title = "BBPlus",
                    Description = "qwerty",
                }
            };

            List<Hotel> hotels = new List<Hotel>
            {
                new Hotel
                {
                    Name = "PENSION HOCHWIMMER",
                    Category = 4,
                    TypeOfFood = typeOfFoods[0]
                },
                new Hotel
                {
                    Name = "HUBERTUSHOF HOTEL",
                    Category = 3,
                    TypeOfFood = typeOfFoods[1]
                },
                new Hotel
                {
                    Name = "ANTONIUS HOTEL",
                    Category = 4,
                    TypeOfFood = typeOfFoods[2]
                }
            };

            context.Countries.AddRange(countries);
            context.HealthResorts.AddRange(healthResorts);
            context.TypeOfFoods.AddRange(typeOfFoods);
            context.Hotels.AddRange(hotels);
            context.SaveChanges();

            List<Tour> tours = new List<Tour>
            {
                new Tour
                {
                    Price = 800,
                    Nights = 15,
                    Country = countries[0],
                    HealthResort = healthResorts[0],
                    Hotel = hotels[0]
                },
                new Tour
                {
                    Price = 650,
                    Nights = 10,
                    Country = countries[1],
                    HealthResort = healthResorts[1],
                    Hotel = hotels[1]
                },
                new Tour
                {
                    Price = 350,
                    Nights = 5,
                    Country = countries[2],
                    HealthResort = healthResorts[2],
                    Hotel = hotels[2]
                }                
            };

            context.Tours.AddRange(tours);
            context.SaveChanges();
        }
    }
}