using System;
using System.ComponentModel.DataAnnotations;
using TourOperator.Domain.Data.DomainModel.Enums;

namespace TourOperator.Domain.Data.DomainModel
{
    public class Hotel
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public int? Category { get; set; }        
        public TypeOfFoodEnum TypeOfFood { get; set; }
        public byte[] TimestampBytes { get; set; }
    }
}
