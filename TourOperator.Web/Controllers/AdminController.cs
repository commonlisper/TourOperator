using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace TourOperator.Web.Controllers
{
    [Authorize]
    public class AdminController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Countries()
        {
            return View();
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