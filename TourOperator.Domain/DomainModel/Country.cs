using System;
using System.ComponentModel.DataAnnotations;

namespace TourOperator.Domain.Data.DomainModel
{
    public class Country
    {        
        public Guid Id { get; set; }
        
        [Required]
        public string Name { get; set; }

        [Timestamp]
        public byte[] TimestampBytes { get; set; }
    }
}
