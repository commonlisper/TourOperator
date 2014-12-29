using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TourOperator.Domain.DataAccessLayer;
using TourOperator.Domain.DataAccessLayer.Abstract;
using TourOperator.Web.Models.ViewModels;

namespace TourOperator.Web.Controllers
{
    public class CountryController : Controller
    {
        private readonly IUnitOfWork _unitOfWork = new UnitOfWork(new DomainDbContext());

        public ActionResult Details(Guid id)
        {
            CountryDetailsViewModel viewModel = new CountryDetailsViewModel()
            {
                Country = _unitOfWork.CountryRepository.Find(id),
                Countries = _unitOfWork.CountryRepository.Get()
            };

            return View(viewModel);
        }
    }
}