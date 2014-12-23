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
    public class GenericRepository<TEntity> : IGenericRepository<TEntity> where TEntity : class
    {
        private readonly DbContext _context;
        private readonly DbSet<TEntity> _dbSet;

        public GenericRepository(DbContext context)
        {
            _context = context;
            _dbSet = _context.Set<TEntity>();
        }

        public IEnumerable<TEntity> Get(Expression<Func<TEntity, bool>> where = null,
            Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null,
            string includeProperties = null)
        {
            IQueryable<TEntity> entitySet = _dbSet;

            if (where != null)
            {
                entitySet = entitySet.Where(where);
            }

            if (includeProperties != null)
            {
                entitySet =
                    includeProperties.Split(new[] { ',' }, StringSplitOptions.RemoveEmptyEntries)
                        .Aggregate(entitySet, (current, property) => current.Include(property));
            }

            return orderBy != null ? orderBy(entitySet).ToList() : entitySet.ToList();
        }

        public TEntity Find(object id)
        {
            return _dbSet.Find(id);
        }

        public void Insert(TEntity entity)
        {
            _dbSet.Add(entity);
        }

        public void Delete(object id)
        {
            _dbSet.Remove(_dbSet.Find(id));
        }

        public void Delete(TEntity entity)
        {
            _dbSet.Remove(entity);
        }

        public void Update(TEntity entity)
        {
            _dbSet.Attach(entity);
            _context.Entry(entity).State = EntityState.Modified;
        }
    }
}
