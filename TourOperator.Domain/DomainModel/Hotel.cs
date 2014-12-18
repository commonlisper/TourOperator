using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TourOperator.Domain.DomainModel
{
    public class Hotel
    {
        public int Id { get; set; }
        
        [MaxLength(200)]
        public string Name { get; set; }

        public int Category { get; set; }
        
        [MaxLength(2)]
        public string TypeOfFood { get; set; }
    }
}
