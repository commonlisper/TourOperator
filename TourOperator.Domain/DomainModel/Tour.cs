using System;
using System.ComponentModel.DataAnnotations;

namespace TourOperator.Domain.Data.DomainModel
{
    public class Tour
    {
        public int Id { get; set; }
        
        [Required]
        public decimal Price { get; set; }                
        public uint Nights { get; set; }
        public DateTime? StartedOn { get; set; }
        public DateTime? EndedOn { get; set; }

        [Timestamp]
        public byte[] TimestampBytes { get; set; }
    }
}
