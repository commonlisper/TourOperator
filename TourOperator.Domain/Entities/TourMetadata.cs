using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TourOperator.Domain.Data.Entities
{
    [MetadataType(typeof(TourMetadata))]
    public partial class Tour
    {
        public class TourMetadata
        {
            [Display(Name = "Стоимость тура")]
            [Required(ErrorMessage = "Стоимость не задана")]
            [Range(0.00, double.MaxValue, ErrorMessage = "Стоимость не может быть нулевой или такой большой")]
            [DataType(DataType.Currency)]
            public decimal Price { get; set; }

            [Display(Name = "Количество ночей")]
            [Required(ErrorMessage = "Количество ночей не может быть нулевым")]    
            [Range(1, int.MaxValue)]
            public int Nights { get; set; }

            [Display(Name = "Дата начала тура")]
            public DateTime? StartedOn { get; set; }
            
            [Display(Name = "Дата окончания тура")]
            public DateTime? EndedOn { get; set; }
        }
    }
}
