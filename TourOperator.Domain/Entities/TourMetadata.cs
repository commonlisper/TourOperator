using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace TourOperator.Domain.Data.Entities
{
    [MetadataType(typeof(TourMetadata))]
    public partial class Tour
    {
        public class TourMetadata
        {
            [Display(Name = "Стоимость тура")]
            [Required(ErrorMessage = "Поле 'Стоимость тура' не задана")]           
            public int Price { get; set; }

            [Display(Name = "Количество ночей")]
            [Required(ErrorMessage = "Поле 'Количество ночей' не задано")]
            [Range(1, Int32.MaxValue, ErrorMessage = "Значение поля 'Количество ночей' вышло за границы")]
            public int Nights { get; set; }
        }
    }
}
