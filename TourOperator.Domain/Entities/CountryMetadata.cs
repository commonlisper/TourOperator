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
            public string Name { get; set; }
        }

        // Validation
        public void Validate(ModelStateDictionary modelState)
        {
            if (String.IsNullOrEmpty(this.Name))
            {
                modelState.AddModelError("Name", "Недопустимое название страны");
            }
            else if (this.Name.Length < 3)
            {
                modelState.AddModelError("Name", "Недопустимая длина строки (> 3 символов)");
            }           
        }
    }
}
