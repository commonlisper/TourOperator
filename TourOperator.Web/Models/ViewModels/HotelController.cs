using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TourOperator.Domain.DataAccessLayer;
using TourOperator.Domain.DataAccessLayer.Abstract;

namespace TourOperator.Web.Models.ViewModels
{
    public class HotelController : Controller
    {
        private readonly IUnitOfWork _unitOfWork = new UnitOfWork(new DomainDbContext());

        public ActionResult Details(Guid id)
        {
            return View(_unitOfWork.HotelRepository.Find(id));
        }
    }
}