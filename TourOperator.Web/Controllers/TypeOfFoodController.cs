using System;
using System.Web.Mvc;
using TourOperator.Domain.DataAccessLayer;
using TourOperator.Domain.DataAccessLayer.Abstract;

namespace TourOperator.Web.Controllers
{
    public class TypeOfFoodController : Controller
    {
        private readonly IUnitOfWork _unitOfWork = new UnitOfWork(new DomainDbContext());

        public ActionResult Details(Guid id)
        {
            return View(_unitOfWork.TypeOfFoodRepository.Find(id));
        }
    }
}