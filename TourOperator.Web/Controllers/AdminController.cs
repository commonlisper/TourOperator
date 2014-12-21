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
        private readonly IUnitOfWork _unitOfWork = new UnitOfWork(new DomainDbContext());

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Countries()
        {
            return View(_unitOfWork.CountryRepository.Get(includeProperties: "Tours"));
        }

        public ActionResult AddCountry()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AddCountry(Country newCountry)
        {
            if (ModelState.IsValid)
            {
                _unitOfWork.CountryRepository.Insert(newCountry);
            }

            return RedirectToAction("Countries");
        }

        public ActionResult EditCountry(Guid id)
        {
            throw new NotImplementedException();
        }

        public ActionResult RemoveCountry(Guid id)
        {
            if (ModelState.IsValid)
            {
                _unitOfWork.CountryRepository.Delete(id);
            }

            return RedirectToAction("Countries");
        }

        public ActionResult Tours()
        {
            return View(_unitOfWork.TourRepository.Get(includeProperties: "Country"));
        }

        public ActionResult HealthResorts()
        {
            throw new NotImplementedException();
        }

        public ActionResult Hotels()
        {
            throw new NotImplementedException();
        }

        public ActionResult EditTour(Guid id)
        {
            throw new NotImplementedException();
        }

        public ActionResult RemoveTour(Guid id)
        {
            if (ModelState.IsValid)
            {
                _unitOfWork.TourRepository.Delete(id);
            }

            return RedirectToAction("Tours");
        }
    }
}