using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Management.Instrumentation;
using System.Runtime;
using System.Web;
using System.Web.Mvc;
using TourOperator.Domain.Data.DomainModel;
using TourOperator.Domain.Data.Entities;
using TourOperator.Domain.DataAccessLayer;
using TourOperator.Domain.DataAccessLayer.Abstract;
using TourOperator.Domain.DataAccessLayer.Repositories;
using TourOperator.Web.Models.ModelViews;

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

        #region Countries

        public ActionResult Countries()
        {
            return View(_unitOfWork.CountryRepository.Get(includeProperties: "Tours").OrderBy(c => c.Name));
        }

        public ActionResult AddCountry()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AddCountry(Country newCountry)
        {
            Country.Validate(newCountry, ModelState);

            if (_unitOfWork.CountryRepository.Get(c => c.Name == newCountry.Name).Any())
            {
                ModelState.AddModelError("Name", "Такое название страны уже существует, введите другое");
            }

            if (ModelState.IsValid)
            {
                _unitOfWork.CountryRepository.Insert(newCountry);
                return RedirectToAction("Countries");
            }

            return View(newCountry);
        }

        public ActionResult EditCountry(Guid id)
        {
            return View(_unitOfWork.CountryRepository.Find(id));
        }

        [HttpPost]
        public ActionResult EditCountry(Country updatedCoutry)
        {
            Country.Validate(updatedCoutry, ModelState);

            if (ModelState.IsValid)
            {
                _unitOfWork.CountryRepository.Update(updatedCoutry);
                return RedirectToAction("Countries");
            }

            return View(updatedCoutry);
        }

        public ActionResult RemoveCountry(Guid id)
        {
            if (ModelState.IsValid)
            {
                _unitOfWork.CountryRepository.Delete(id);
            }

            return RedirectToAction("Countries");
        }

        #endregion


        #region Tours

        public ActionResult Tours()
        {
            return View(_unitOfWork.TourRepository.Get(includeProperties: "Country"));
        }

        public ActionResult AddTour()
        {
            if (!_unitOfWork.CountryRepository.Get().Any())
            {
                TempData.Add("Message", "Для добавления Тура добавьте хотябы одну Страну");
                return RedirectToAction("Countries");
            }

            TourModelView viewModel = new TourModelView
            {
                AvaliableCountries =
                    _unitOfWork.CountryRepository.Get()
                        .Select(c => new SelectListItem { Text = c.Name, Value = c.Id.ToString() })
            };

            return View(viewModel);
        }

        [HttpPost]
        public ActionResult AddTour(TourModelView tourModelView)
        {
            throw new NotImplementedException();
        }

        #endregion


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