using System;
using TourOperator.Domain.Data.DomainModel;

namespace TourOperator.Domain.Data.Entities
{
    public class HealthResort
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public byte[] TimestampBytes { get; set; }

        public virtual Hotel Hotel { get; set; }
        public virtual Tour Tour { get; set; }
    }
}
