using System.ComponentModel.DataAnnotations;

namespace TourOperator.Domain.Data.DomainModel
{
    public class HealthResort
    {
        public int Id { get; set; }
        
        [Required]
        [MaxLength(200)]
        public string Name { get; set; }

        [Timestamp]
        public byte[] TimestampBytes { get; set; }
    }
}
