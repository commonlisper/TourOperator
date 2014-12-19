using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using TourOperator.Domain.DataAccessLayer.Abstract;

namespace TourOperator.Domain.DataAccessLayer.Repositories
{
    public class GenericRepository<TEntiry> : IRepository<TEntiry>
    {
        private readonly DbContext _context;

        public GenericRepository(DbContext context)
        {
            _context = context;
        }

        public IEnumerable<TEntiry> Get(Expression<Func<TEntiry, bool>> filter = null, Func<IQueryable<TEntiry>, IOrderedQueryable<TEntiry>> orderBy = null, string includeProperties = "")
        {
            throw new NotImplementedException();
        }

        public TEntiry Find(object id)
        {
            throw new NotImplementedException();
        }

        public void Insert(TEntiry entity)
        {
            throw new NotImplementedException();
        }

        public void Delete(object id)
        {
            throw new NotImplementedException();
        }

        public void Delete(TEntiry entity)
        {
            throw new NotImplementedException();
        }

        public void Update(TEntiry entity)
        {
            throw new NotImplementedException();
        }
    }
}
