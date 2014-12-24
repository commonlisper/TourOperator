using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TourOperator.Domain.Data.DomainModel;
using TourOperator.Domain.Data.Entities;
using TourOperator.Domain.DataAccessLayer.Abstract;
using TourOperator.Domain.DataAccessLayer.Repositories;

namespace TourOperator.Domain.DataAccessLayer
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly DbContext _context;

        public UnitOfWork(DbContext context)
        {
            _context = context;
            CountryRepository = new GenericRepository<Country>(_context);
            TourRepository = new GenericRepository<Tour>(_context);
            HealthResortRepository = new GenericRepository<HealthResort>(_context);
            HotelRepository = new GenericRepository<Hotel>(_context);
            TypeOfFoodRepository = new GenericRepository<TypeOfFood>(_context);
        }

        private bool _disposed;

        protected virtual void Dispose(bool disposing)
        {
            if (!_disposed)
            {
                if (disposing)
                {
                    _context.Dispose();
                }
            }

            _disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        public IGenericRepository<Country> CountryRepository { get; private set; }

        public IGenericRepository<Tour> TourRepository { get; private set; }

        public IGenericRepository<HealthResort> HealthResortRepository { get; private set; }

        public IGenericRepository<Hotel> HotelRepository { get; private set; }

        public IGenericRepository<TypeOfFood> TypeOfFoodRepository { get; private set; }

        public void Save()
        {
            _context.SaveChanges();
        }
    }
}
