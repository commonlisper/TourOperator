using System;
using System.Collections.Generic;
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

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Countries()
        {
            return View(_countryRepository.Get(includeProperties: "Tours"));
        }

        public ActionResult Tours()
        {
            throw new NotImplementedException();
        }

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