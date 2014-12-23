using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;
using TourOperator.Domain.Data.Entities;

namespace TourOperator.Web.Models.ViewModels
{
    public class TourViewModel
    {
        public Tour Tour { get; set; }
        
        [Display(Name = "Страна для тура")]
        public Guid SelectedAvaliableCountryId { get; set; }
        public IEnumerable<SelectListItem> AvaliableCountries { get; set; }
    }
}