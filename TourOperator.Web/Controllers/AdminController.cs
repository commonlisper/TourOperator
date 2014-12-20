using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TourOperator.Domain.Data.DomainModel;
using TourOperator.Domain.DataAccessLayer;
using TourOperator.Domain.DataAccessLayer.Abstract;
using TourOperator.Domain.DataAccessLayer.Repositories;

namespace TourOperator.Web.Controllers
{
    [Authorize]
    public class AdminController : Controller
    {
        private readonly IGenericRepository<Country> _countryRepository =
            new GenericRepository<Country>(new DomainDbContext());

        private readonly IGenericRepository<Tour> _tourRepository = 
            new GenericRepository<Tour>(new DomainDbContext());

        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult Countries()
        {
            return View(_countryRepository.Get(includeProperties: "Tours"));
        }

        public ActionResult Tours()
        {
            return View(_tourRepository.Get(includeProperties: "Country"));
        }

        public ActionResult HealthResorts()
        {
            throw new NotImplementedException();
        }

        public ActionResult Hotels()
        {
            throw new NotImplementedException();
        }

        public ActionResult EditCountry(Guid id)
        {
            throw new NotImplementedException();
        }

        [HttpGet]
        public ActionResult RemoveCountry(Guid id)
        {           
            if (ModelState.IsValid)
            {
                _countryRepository.Delete(id);                
            }

            return RedirectToAction("Countries");
        }

        public ActionResult EditTour(Guid id)
        {
            throw new NotImplementedException();
        }
    }
}