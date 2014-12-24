using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TourOperator.Domain.Data.DomainModel.Enums;

namespace TourOperator.Domain.Data.Entities
{
    public partial class TypeOfFood
    {
        public Guid Id { get; set; }
        public TypeOfFoodEnum FoodType { get; set; }    
        public string Description { get; set; }
    }
}
