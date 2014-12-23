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
                _unitOfWork.Save();

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
                _unitOfWork.Save();

                return RedirectToAction("Countries");
            }

            return View(updatedCoutry);
        }

        public ActionResult RemoveCountry(Guid id)
        {
            if (ModelState.IsValid)
            {
                _unitOfWork.CountryRepository.Delete(id);
                _unitOfWork.Save();
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

            TourViewModel viewModel = new TourViewModel
            {
                AvaliableCountries =
                    GetAvaliableCountries()
                        .Select(c => new SelectListItem { Text = c.Name, Value = c.Id.ToString() })
            };

            return View(viewModel);
        }

        [HttpPost]
        public ActionResult AddTour(TourViewModel tourViewModel)
        {
            Tour.TourMetadata.Validate(tourViewModel.Tour, ModelState);

            if (ModelState.IsValid)
            {
                Country country = _unitOfWork.CountryRepository.Find(tourViewModel.SelectedAvaliableCountryId);
                tourViewModel.Tour.Country = country;
                _unitOfWork.TourRepository.Insert(tourViewModel.Tour);
                _unitOfWork.Save();

                return RedirectToAction("Tours");
            }

            tourViewModel.AvaliableCountries = AvaliableCountriesAsSelectList();
            return View(tourViewModel);
        }

        private IEnumerable<Country> GetAvaliableCountries()
        {
            return _unitOfWork.CountryRepository.Get();
        }

        private IEnumerable<SelectListItem> AvaliableCountriesAsSelectList()
        {
            return
                GetAvaliableCountries()
                    .Select(c => new SelectListItem { Text = c.Name, Value = c.Id.ToString() });
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
                _unitOfWork.Save();
            }

            return RedirectToAction("Tours");
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
    }
}