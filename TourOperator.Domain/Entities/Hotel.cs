using System;
using System.Collections.Generic;
using TourOperator.Domain.Data.DomainModel.Enums;

namespace TourOperator.Domain.Data.Entities
{
    public class Hotel
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public int? Category { get; set; }        
        public TypeOfFoodEnum TypeOfFood { get; set; }
        public byte[] TimestampBytes { get; set; }

        public virtual IEnumerable<Tour> Tours { get; set; }
    }
}
