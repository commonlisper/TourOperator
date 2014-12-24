using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using TourOperator.Domain.Data.DomainModel.Enums;

namespace TourOperator.Domain.Data.Entities
{
    [MetadataType(typeof(HotelMetadata))]
    public partial class Hotel
    {
        public class HotelMetadata
        {
            [Required(ErrorMessage = "Поле 'Название отеля' не задано")]
            [StringLength(200, MinimumLength = 2, ErrorMessage = "Поле 'Название отеля' требует более 2х символов")]
            [Display(Name = "Название отеля")]
            public string Name { get; set; }

            [Display(Name = "Категория отеля")]
            [Range(1, 5)]
            public int? Category { get; set; }

            [Required(ErrorMessage = "Поле 'Тип питания' не задано")]
            [Display(Name = "Тип питания")]
            public TypeOfFoodEnum TypeOfFood { get; set; }

            [AllowHtml]
            [Display(Name = "Описание отеля")]
            public string Description { get; set; }
        }

        public static void Validate(Hotel hotelToValidate, ModelStateDictionary modelState)
        {
            if (String.IsNullOrEmpty(hotelToValidate.Name))
            {
                modelState.AddModelError("Name", "Поле 'Название отеля' не задано");
            }

            if (hotelToValidate.Name.Length <= 2)
            {
                modelState.AddModelError("Name", "Поле 'Название отеля' требует более 2х символов");
            }
        }
    }    
}
