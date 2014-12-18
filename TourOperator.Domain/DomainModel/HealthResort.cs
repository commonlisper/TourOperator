using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TourOperator.Domain.DomainModel
{
    public class HealthResort
    {
        public int Id { get; set; }
        
        [Required]
        [MaxLength(200)]
        public string Name { get; set; }

        [Timestamp]
        public byte[] TimestampBytes { get; set; }
    }
}
