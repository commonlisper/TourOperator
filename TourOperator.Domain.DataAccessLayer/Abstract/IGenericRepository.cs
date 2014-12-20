using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace TourOperator.Domain.DataAccessLayer.Abstract
{
    public interface IGenericRepository<TEntity> where TEntity : class
    {
        IEnumerable<TEntity> Get(Expression<Func<TEntity, bool>> where = null,
            Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null,
            string includeProperties = "");
        
        TEntity Find(object id);
        void Insert(TEntity entity);
        void Delete(object id);
        void Delete(TEntity entity);
        void Update(TEntity entity);
    }
}
