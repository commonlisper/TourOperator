using System;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace TourOperator.Domain.Data.Entities
{
    [MetadataType(typeof(CountryMetadata))]
    public partial class Country
    {
        public class CountryMetadata
        {
            [Required(ErrorMessage = "Поле 'Название страны' не задано")]
            [StringLength(200, MinimumLength = 2, ErrorMessage = "Поле 'Название страны' требует более 2х символов")]
            [Display(Name = "Название Страны")]
            public string Name { get; set; }
        }
        
        public static void Validate(Country countryToValidate, ModelStateDictionary modelState)
        {
            if (String.IsNullOrEmpty(countryToValidate.Name))
            {
                modelState.AddModelError("Name", "Поле 'Название страны' не задано'");
            }
            else if (countryToValidate.Name.Length < 2)
            {
                modelState.AddModelError("Name", "Поле 'Название страны' требует более 2х символов");
            }           
        }
    }
}
