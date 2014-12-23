using System;
using System.Web;

namespace TourOperator.Domain.Data.Entities
{
    public partial class Tour
    {
        public Guid Id { get; set; }
        public int Price { get; set; }
        public int Nights { get; set; }
        public byte[] TimestampBytes { get; set; }
        public Guid HealthResordId { get; set; }
        public Guid HotelId { get; set; }
        public Guid CountryId { get; set; }
        
        public virtual Country Country { get; set; }
        public virtual HealthResort HealthResort { get; set; }
        public virtual Hotel Hotel { get; set; }
    }
}
