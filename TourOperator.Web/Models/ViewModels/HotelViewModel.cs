using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TourOperator.Domain.Data.Entities;

namespace TourOperator.Web.Models.ViewModels
{
    public class HotelViewModel
    {
        public Hotel Hotel { get; set; }
        public IEnumerable<SelectListItem> TypeOfFoods { get; set; }
        
        [Display(Name = "Тип питания")]
        public Guid SelectedTypeOfFoodId { get; set; }
    }
}