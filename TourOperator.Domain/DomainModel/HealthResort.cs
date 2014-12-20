using System;
using System.ComponentModel.DataAnnotations;

namespace TourOperator.Domain.Data.DomainModel
{
    public class HealthResort
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public byte[] TimestampBytes { get; set; }
      
        public virtual Hotel Hotel { get; set; }
    }
}
