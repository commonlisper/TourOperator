using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TourOperator.Domain.Data.Entities
{
    public partial class TypeOfFood
    {
        public Guid Id { get; set; }
        public string Title { get; set; }    
        public string Description { get; set; }

        public Guid HotelId { get; set; }
        public virtual Hotel Hotel { get; set; }
    }
}
