using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace TourOperator.Domain.Data.Entities
{
    [MetadataType(typeof(TypeOfFoodMetadata))]
    public partial class TypeOfFood
    {
        public class TypeOfFoodMetadata
        {
            [Required(ErrorMessage = "Поле 'Тип питания' не задано")]
            [Display(Name = "Тип питания")]            
            public string Title { get; set; }

            [Required(ErrorMessage = "Поле 'Описание' не задано")]
            [AllowHtml]
            [Display(Name = "Описание")]            
            public string Description { get; set; }                       
        }

        public bool CanRemove { get; set; }

        public static void Validate(TypeOfFood typeOfFoodToValidate, ModelStateDictionary modelState)
        {
            if (String.IsNullOrEmpty(typeOfFoodToValidate.Title))
            {
                modelState.AddModelError("Title", "Поле 'Тип питания' не задано");
            }

            if (typeOfFoodToValidate.Title.Length < 2)
            {
                modelState.AddModelError("Title", "Поле 'Тип питания' должно быть более 1 символа");
            }

            if (string.IsNullOrEmpty(typeOfFoodToValidate.Description))
            {
                modelState.AddModelError("Description", "Поле 'Описание' не задано");
            }
        }
    }
}
