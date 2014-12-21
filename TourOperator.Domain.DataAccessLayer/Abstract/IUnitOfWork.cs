using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TourOperator.Domain.Data.DomainModel;

namespace TourOperator.Domain.DataAccessLayer.Abstract
{
    public interface IUnitOfWork : IDisposable
    {
        IGenericRepository<Country> CountryRepository { get; }
        IGenericRepository<Tour> TourRepository { get; }
        IGenericRepository<HealthResort> HealthResortRepository { get; }
        IGenericRepository<Hotel> HotelRepository { get; }
        void Save();
    }
}
