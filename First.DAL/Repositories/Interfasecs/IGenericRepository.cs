using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace First.DAL.Repositories.Interfasecs
{
    public interface IGenericRepository<TEntity> where TEntity : BaseEntity
    {
        void Add(TEntity entity);
        void Delete(TEntity entity);
        IEnumerable<TEntity> GetAll(bool WithTracking = false);
        IEnumerable<TEntity> GetAll(Expression<Func<TEntity, bool>> predicate);

        //IEnumerable<TEntity> GetAll<TResult>(Exception<Func<TEntity, TResult>> Selector);


        TEntity? GetById(int id);
        void Update(TEntity entity);
    }
}
