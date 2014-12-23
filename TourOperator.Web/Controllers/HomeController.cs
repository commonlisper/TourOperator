using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TourOperator.Domain.DataAccessLayer;

namespace TourOperator.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly DomainDbContext _dbContext = new DomainDbContext();

        public ActionResult Index()
        {
            var countries = _dbContext.Countries.ToList();
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}