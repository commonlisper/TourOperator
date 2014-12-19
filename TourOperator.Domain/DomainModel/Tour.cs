using System;
using System.ComponentModel.DataAnnotations;

namespace TourOperator.Domain.Data.DomainModel
{
    public class Tour
    {
        public Guid Id { get; set; }
        public decimal Price { get; set; }                
        public uint Nights { get; set; }
        public DateTime? StartedOn { get; set; }
        public DateTime? EndedOn { get; set; }
        public byte[] TimestampBytes { get; set; }
    }
}
