using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TourOperator.Domain.DomainModel.Enums;

namespace TourOperator.Domain.DomainModel
{
    public class Hotel
    {
        public int Id { get; set; }
        
        [Required]
        [MaxLength(200)]
        public string Name { get; set; }

        public int? Category { get; set; }
        
        [Required]
        public TypeOfFoodEnum TypeOfFood { get; set; }

        [Timestamp]
        public byte[] TimestampBytes { get; set; }
    }
}
