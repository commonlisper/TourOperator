using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TourOperator.Domain.Data.Entities;

namespace TourOperator.Web.Models.ViewModels
{
    public class CountryDetailsViewModel
    {
        public Country Country { get; set; }
        public IEnumerable<Country> Countries { get; set; }
    }
}