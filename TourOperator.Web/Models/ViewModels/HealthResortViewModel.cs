using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TourOperator.Domain.Data.Entities;

namespace TourOperator.Web.Models.ViewModels
{
    public class HealthResortViewModel
    {
        public Guid SelectedTourId { get; set; }
        public Guid SelectedHotelId { get; set; }
        public IEnumerable<Tour> AvaliableTours { get; set; }
        public IEnumerable<Hotel> AvaliableHotels { get; set; }
    }
}