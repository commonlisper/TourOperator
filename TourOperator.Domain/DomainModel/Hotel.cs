using System.ComponentModel.DataAnnotations;
using TourOperator.Domain.Data.DomainModel.Enums;

namespace TourOperator.Domain.Data.DomainModel
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
