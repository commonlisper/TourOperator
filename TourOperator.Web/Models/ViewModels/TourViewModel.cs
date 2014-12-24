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
        
        [Display(Name = "Страна тура")]
        public Guid SelectedCountryId { get; set; }

        [Display(Name = "Курорт тура")]
        public Guid SelecterHealthResortId { get; set; }

        [Display(Name = "Отель тура")]
        public Guid SelectedHotelId { get; set; }
        public IEnumerable<SelectListItem> Countries { get; set; }
        public IEnumerable<SelectListItem> HealthResorts { get; set; }
        public IEnumerable<SelectListItem> Hotels { get; set; }
    }
}