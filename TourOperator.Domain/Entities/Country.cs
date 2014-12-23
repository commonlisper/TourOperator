using System;
using System.Collections.Generic;
using TourOperator.Domain.Data.DomainModel;

namespace TourOperator.Domain.Data.Entities
{
    public partial class Country
    {
        public Country()
        {
            Tours = new HashSet<Tour>();
        }

        public Guid Id { get; set; }    
        public string Name { get; set; }
        public byte[] TimestampBytes { get; set; }

        public virtual ICollection<Tour> Tours { get; set; }
    }
}
