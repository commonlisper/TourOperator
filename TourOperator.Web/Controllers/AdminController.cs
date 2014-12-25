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
using TourOperator.Web.Models.ViewModels;

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
            return View(_unitOfWork.TourRepository.Get(includeProperties: "Country, HealthResort, Hotel"));
        }

        public ActionResult AddTour()
        {
            TourViewModel viewModel = new TourViewModel
            {
                Countries = GetCountriesAsSelectList(),
                HealthResorts = GetHealthResortsAsSelectList(),
                Hotels = GetHotelsAsSelectList()
            };

            return View(viewModel);
        }

        private IEnumerable<SelectListItem> GetHotelsAsSelectList()
        {
            return
                _unitOfWork.HotelRepository.Get()
                    .Select(h => new SelectListItem { Text = h.Name, Value = h.Id.ToString() });
        }

        private IEnumerable<SelectListItem> GetHealthResortsAsSelectList()
        {
            return
                _unitOfWork.HealthResortRepository.Get()
                    .Select(hr => new SelectListItem { Text = hr.Name, Value = hr.Id.ToString() });
        }

        [HttpPost]
        public ActionResult AddTour(TourViewModel tourViewModel)
        {
            Tour.Validate(tourViewModel.Tour, ModelState);

            if (ModelState.IsValid)
            {
                tourViewModel.Tour.CountryId = tourViewModel.SelectedCountryId;
                tourViewModel.Tour.HealthResortId = tourViewModel.SelecterHealthResortId;
                tourViewModel.Tour.HotelId = tourViewModel.SelectedHotelId;

                _unitOfWork.TourRepository.Insert(tourViewModel.Tour);
                _unitOfWork.Save();

                return RedirectToAction("Tours");
            }

            tourViewModel.Countries = GetCountriesAsSelectList();
            tourViewModel.HealthResorts = GetHealthResortsAsSelectList();
            tourViewModel.Hotels = GetHotelsAsSelectList();
            return View(tourViewModel);
        }

        private IEnumerable<SelectListItem> GetCountriesAsSelectList()
        {
            return
                _unitOfWork.CountryRepository.Get()
                    .Select(c => new SelectListItem { Text = c.Name, Value = c.Id.ToString() });
        }

        public ActionResult EditTour(Guid id)
        {
            Tour tourToUpdate = _unitOfWork.TourRepository.Find(id);

            TourViewModel tourViewModel = new TourViewModel
            {
                SelectedCountryId = tourToUpdate.CountryId,
                SelectedHotelId = tourToUpdate.HotelId,
                SelecterHealthResortId = tourToUpdate.HealthResortId,
                Countries = GetCountriesAsSelectList(),
                HealthResorts = GetHealthResortsAsSelectList(),
                Hotels = GetHotelsAsSelectList(),
                Tour = tourToUpdate
            };

            return View(tourViewModel);
        }

        [HttpPost]
        public ActionResult EditTour(TourViewModel tourViewModel)
        {
            Tour.Validate(tourViewModel.Tour, ModelState);

            if (ModelState.IsValid)
            {
                tourViewModel.Tour.CountryId = tourViewModel.SelectedCountryId;
                tourViewModel.Tour.HealthResortId = tourViewModel.SelecterHealthResortId;
                tourViewModel.Tour.HotelId = tourViewModel.SelectedHotelId;

                _unitOfWork.TourRepository.Update(tourViewModel.Tour);
                _unitOfWork.Save();

                return RedirectToAction("Tours");
            }

            tourViewModel.Countries = GetCountriesAsSelectList();
            tourViewModel.HealthResorts = GetHealthResortsAsSelectList();
            tourViewModel.Hotels = GetHotelsAsSelectList();
            return View(tourViewModel);
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

        #region HealthResorts

        public ActionResult HealthResorts()
        {
            return View(_unitOfWork.HealthResortRepository.Get(includeProperties: "Tours"));
        }

        public ActionResult AddHealthResort()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AddHealthResort(HealthResort newHealthResort)
        {
            HealthResort.Validate(newHealthResort, ModelState);

            if (_unitOfWork.HealthResortRepository.Get(hr => hr.Name == newHealthResort.Name).Any())
            {
                ModelState.AddModelError("Name", "Такое Название курорта уже существует, выберите другое");
            }

            if (ModelState.IsValid)
            {
                _unitOfWork.HealthResortRepository.Insert(newHealthResort);
                _unitOfWork.Save();

                return RedirectToAction("HealthResorts");
            }

            return View(newHealthResort);
        }

        public ActionResult EditHealthResort(Guid id)
        {
            return View(_unitOfWork.HealthResortRepository.Find(id));
        }

        [HttpPost]
        public ActionResult EditHealthResort(HealthResort healthResortToUpdate)
        {
            HealthResort.Validate(healthResortToUpdate, ModelState);

            if (_unitOfWork.HealthResortRepository.Get(hr => hr.Name == healthResortToUpdate.Name).Any())
            {
                ModelState.AddModelError("Name", "Такое Название курорта уже существует, выберите другое");
            }

            if (ModelState.IsValid)
            {
                _unitOfWork.HealthResortRepository.Update(healthResortToUpdate);
                _unitOfWork.Save();

                return RedirectToAction("HealthResorts");
            }

            return View(healthResortToUpdate);
        }

        public ActionResult RemoveHealthResort(Guid id)
        {
            if (ModelState.IsValid)
            {
                _unitOfWork.HealthResortRepository.Delete(id);
                _unitOfWork.Save();
            }

            return RedirectToAction("HealthResorts");
        }

        #endregion

        #region Hotels

        public ActionResult Hotels()
        {
            return View(_unitOfWork.HotelRepository.Get(includeProperties: "Tours, TypeOfFoods").OrderBy(h => h.Name));
        }

        public ActionResult AddHotel()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AddHotel(Hotel newHotel)
        {
            Hotel.Validate(newHotel, ModelState);

            if (ModelState.IsValid)
            {
                _unitOfWork.HotelRepository.Insert(newHotel);
                _unitOfWork.Save();

                return RedirectToAction("Hotels");
            }

            return View(newHotel);
        }

        public ActionResult EditHotel(Guid id)
        {
            return View(_unitOfWork.HotelRepository.Find(id));
        }

        [HttpPost]
        public ActionResult EditHotel(Hotel hotelToUpdate)
        {
            Hotel.Validate(hotelToUpdate, ModelState);

            if (ModelState.IsValid)
            {
                _unitOfWork.HotelRepository.Update(hotelToUpdate);
                _unitOfWork.Save();

                return RedirectToAction("Hotels");
            }

            return View(hotelToUpdate);
        }

        public ActionResult RemoveHotel(Guid id)
        {
            if (ModelState.IsValid)
            {
                _unitOfWork.HotelRepository.Delete(id);
                _unitOfWork.Save();
            }

            return RedirectToAction("Hotels");
        }

        #endregion

        #region TypeOfFoods

        public ActionResult TypeOfFoods()
        {
            return View(_unitOfWork.TypeOfFoodRepository.Get(includeProperties: "Hotel"));
        }

        public ActionResult AddTypeOfFood()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AddTypeOfFood(TypeOfFood newTypeOfFood)
        {
            TypeOfFood.Validate(newTypeOfFood, ModelState);

            if (!ModelState.IsValid) return View(newTypeOfFood);

            _unitOfWork.TypeOfFoodRepository.Insert(newTypeOfFood);
            _unitOfWork.Save();

            return RedirectToAction("TypeOfFoods");
        }

        public ActionResult EditTypeOfFood(Guid id)
        {
            return View(_unitOfWork.TypeOfFoodRepository.Find(id));
        }

        [HttpPost]
        public ActionResult EditTypeOfFood(TypeOfFood typeOfFoodToUpdate)
        {
            TypeOfFood.Validate(typeOfFoodToUpdate, ModelState);

            if (!ModelState.IsValid) return View(typeOfFoodToUpdate);

            _unitOfWork.TypeOfFoodRepository.Insert(typeOfFoodToUpdate);
            _unitOfWork.Save();

            return RedirectToAction("TypeOfFoods");
        }

        public ActionResult RemoveTypeOfFood(Guid id)
        {
            if (ModelState.IsValid)
            {
                _unitOfWork.TypeOfFoodRepository.Delete(id);
                _unitOfWork.Save();
            }

            return RedirectToAction("TypeOfFoods");
        }

        #endregion
    }
}