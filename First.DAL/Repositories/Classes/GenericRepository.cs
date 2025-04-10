using First.DAL.Data.Contexts;
using First.DAL.Repositories.Interfasecs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace First.DAL.Repositories.Classes
{
    public class GenericRepository<TEntity>(AppDBContext dbContext) : IGenericRepository<TEntity> where TEntity : BaseEntity
    {
        private readonly AppDBContext _dbContext = dbContext;

        //CRUD OPerations
        // Get Id
        public TEntity? GetById(int id) => _dbContext.Set<TEntity>().Find(id);
        //Get All
        public IEnumerable<TEntity> GetAll(bool WithTracking = false)
        {
            if (WithTracking)
            {
                return _dbContext.Set<TEntity>().Where(E=>E.IsDeleted !=true).ToList();
            }
            else
            {
                return _dbContext.Set<TEntity>().Where(E => E.IsDeleted != true).AsNoTracking().ToList();
            }
        }
        // Insert
        public void Add(TEntity entity)
        {
            _dbContext.Set<TEntity>().Add(entity);
        }
        // Update
        public void Update(TEntity entity)
        {
            _dbContext.Set<TEntity>().Update(entity);
        }
        // Delete
        public void Delete(TEntity entity)
        {
            _dbContext.Set<TEntity>().Remove(entity);
        }

        public IEnumerable<TEntity> GetAll(Expression<Func<TEntity, bool>> predicate)
        {
            return _dbContext.Set<TEntity>()
                .Where(predicate).ToList();    
        }
    }
}
