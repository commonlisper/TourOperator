using System;
using System.Collections.Generic;

namespace TourOperator.Domain.Data.Entities
{
    public partial class Hotel
    {
        public Hotel()
        {
            Tours = new HashSet<Tour>();            
        }

        public Guid Id { get; set; }
        public string Name { get; set; }
        public int? Category { get; set; }
        public string Description { get; set; }
        public byte[] TimestampBytes { get; set; }

        public virtual ICollection<Tour> Tours { get; set; }        
        public virtual TypeOfFood TypeOfFood { get; set; }
    }
}
