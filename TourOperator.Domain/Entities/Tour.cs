using System;

namespace TourOperator.Domain.Data.Entities
{
    public partial class Tour
    {
        public Guid Id { get; set; }
        public decimal Price { get; set; }
        public int Nights { get; set; }
        public DateTime? StartedOn { get; set; }
        public DateTime? EndedOn { get; set; }
        public byte[] TimestampBytes { get; set; }

        public virtual Country Country { get; set; }
        public virtual HealthResort HealthResort { get; set; }
    }
}
