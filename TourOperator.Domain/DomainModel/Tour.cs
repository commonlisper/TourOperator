using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Permissions;
using System.Text;
using System.Threading.Tasks;

namespace TourOperator.Domain.DomainModel
{
    public class Tour
    {
        public int Id { get; set; }
        public decimal Price { get; set; }
        public uint Nights { get; set; }
        public DateTime StartedOn { get; set; }
        public DateTime EndedOn { get; set; }
    }
}
