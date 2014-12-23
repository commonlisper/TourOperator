using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using TourOperator.Domain.Data.DomainModel;
using TourOperator.Domain.Data.DomainModel.Enums;
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
                    Name = "�������"
                },
                new Country
                {
                    Name = "������"
                },
                new Country
                {
                    Name = "������"
                }
            };

            List<HealthResort> healthResorts = new List<HealthResort>
            {
                new HealthResort
                {
                    Name = "���� �� ���"
                },
                new HealthResort
                {
                    Name = "������"
                },
                new HealthResort
                {
                    Name = "��� ����������"
                }                
            };

            List<Hotel> hotels = new List<Hotel>
            {
                new Hotel
                {
                    Name = "PENSION HOCHWIMMER",
                    TypeOfFood = TypeOfFoodEnum.EnglishBreakfast,
                    Category = 4
                },
                new Hotel
                {
                    Name = "HUBERTUSHOF HOTEL",
                    TypeOfFood = TypeOfFoodEnum.BrunchDinnerPlus,
                    Category = 3
                },
                new Hotel
                {
                    Name = "ANTONIUS HOTEL",
                    TypeOfFood = TypeOfFoodEnum.FBPlusExtFB,
                    Category = 4
                }
            };

            context.Countries.AddRange(countries);
            context.HealthResorts.AddRange(healthResorts);
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