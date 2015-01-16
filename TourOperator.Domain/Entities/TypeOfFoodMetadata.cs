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
    }
}
