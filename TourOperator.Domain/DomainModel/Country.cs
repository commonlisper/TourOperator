using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace TourOperator.Domain.Data.DomainModel
{
    public class Country
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
