using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace TourOperator.Domain.Data.Entities
{
    [MetadataType(typeof(HealthResortMetadata))]
    public partial class HealthResort
    {
        public class HealthResortMetadata
        {
            [Required(ErrorMessage = "Поле 'Название курорта' необходимо")]
            [StringLength(200, MinimumLength = 2, ErrorMessage = "Поле 'Название курорта' требует более 2х символов")]
            [Display(Name = "Название курорта")]
            public string Name { get; set; }

            [AllowHtml]
            [Display(Name = "Описание курорта")]
            public string Description { get; set; }
        }

        public static void Validate(HealthResort healthResortToValidate, ModelStateDictionary modelState)
        {
            if (String.IsNullOrEmpty(healthResortToValidate.Name))
            {
                modelState.AddModelError("Name", "Поле 'Название курорта' необходимо");
            }

            if (healthResortToValidate.Name.Length <= 2)
            {
                modelState.AddModelError("Name", "Поле 'Название курорта' требует более 2х символов");
            }            
        }
    }

}
