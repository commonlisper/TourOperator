using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TourOperator.Domain.Data.Entities;

namespace TourOperator.Web.Validation
{
    public static class ModelValidator
    {
        public static void ValidateCountry(Country country, ModelStateDictionary modelState)
        {
            if (String.IsNullOrEmpty(country.Name))
            {
                modelState.AddModelError("Name", "Поле 'Название страны' не задано'");
            }

            if (country.Name.Length <= 2)
            {
                modelState.AddModelError("Name", "Поле 'Название страны' требует более 2х символов");
            }
        }

        public static void ValidateTour(Tour tour, ModelStateDictionary modelState)
        {
            if (tour.Price < 0)
            {
                modelState.AddModelError("Price", "Поле 'Стоимость тура' не может быть меньше ноля");
            }

            if (tour.Nights == 0)
            {
                modelState.AddModelError("Nights", "Поле 'Количество ночей' не может быть нулевым");
            }

            if (tour.Nights < 0)
            {
                modelState.AddModelError("Nights", "Поле 'Количество ночей' не может быть меньше ноля");
            }
        }

        public static void ValidateHotel(Hotel hotel, ModelStateDictionary modelState)
        {
            if (String.IsNullOrEmpty(hotel.Name))
            {
                modelState.AddModelError("Name", "Поле 'Название отеля' не задано");
            }

            if (hotel.Name.Length <= 2)
            {
                modelState.AddModelError("Name", "Поле 'Название отеля' требует более 2х символов");
            }
        }

        public static void ValidateHealthResort(HealthResort healthResort, ModelStateDictionary modelState)
        {
            if (String.IsNullOrEmpty(healthResort.Name))
            {
                modelState.AddModelError("Name", "Поле 'Название курорта' необходимо");
            }

            if (healthResort.Name.Length <= 2)
            {
                modelState.AddModelError("Name", "Поле 'Название курорта' требует более 2х символов");
            }
        }

        public static void ValidateTypeOfFood(TypeOfFood typeOfFood, ModelStateDictionary modelState)
        {
            if (String.IsNullOrEmpty(typeOfFood.Title))
            {
                modelState.AddModelError("Title", "Поле 'Тип питания' не задано");
            }

            if (typeOfFood.Title.Length < 2)
            {
                modelState.AddModelError("Title", "Поле 'Тип питания' должно быть более 1 символа");
            }

            if (string.IsNullOrEmpty(typeOfFood.Description))
            {
                modelState.AddModelError("Description", "Поле 'Описание' не задано");
            }
        }
    }
}