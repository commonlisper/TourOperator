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
            [Required(ErrorMessage = "Недопустимое название страны")]
            [StringLength(200, MinimumLength = 3, ErrorMessage = "Более 3х символов")]
            [Display(Name = "Название Страны")]
            public string Name { get; set; }
        }
        
        public static void Validate(Country countryToValidate, ModelStateDictionary modelState)
        {
            if (String.IsNullOrEmpty(countryToValidate.Name))
            {
                modelState.AddModelError("Name", "Недопустимое название страны");
            }
            else if (countryToValidate.Name.Length < 3)
            {
                modelState.AddModelError("Name", "Недопустимая длина строки (> 3 символов)");
            }           
        }
    }
}
