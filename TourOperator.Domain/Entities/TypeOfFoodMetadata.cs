using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;
using TourOperator.Domain.Data.DomainModel.Enums;

namespace TourOperator.Domain.Data.Entities
{
    [MetadataType(typeof(TypeOfFoodMetadata))]
    public partial class TypeOfFood
    {
        public class TypeOfFoodMetadata
        {
            [Required(ErrorMessage = "Поле 'Тип питания' не задано")]
            public TypeOfFoodEnum FoodType { get; set; }

            [AllowHtml]
            public string Description { get; set; }
        }
    }
}
