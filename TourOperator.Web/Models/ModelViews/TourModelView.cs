using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TourOperator.Domain.Data.Entities;

namespace TourOperator.Web.Models.ModelViews
{
    public class TourModelView
    {
        public Tour Tour { get; set; }
        
        [Display(Name = "Страна для тура")]
        public Guid SelectedAvaliableCountryId { get; set; }
        public IEnumerable<SelectListItem> AvaliableCountries { get; set; }
    }
}