using First.DAL.Data.Contexts;
using First.DAL.Repositories.Interfasecs;
using System;
using System.Collections.Generic;
using System.Linq;
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
        public int Add(TEntity entity)
        {
            _dbContext.Set<TEntity>().Add(entity);
            return _dbContext.SaveChanges();
        }
        // Update
        public int Update(TEntity entity)
        {
            _dbContext.Set<TEntity>().Update(entity);
            return _dbContext.SaveChanges();
        }
        // Delete
        public int Delete(TEntity entity)
        {
            _dbContext.Set<TEntity>().Remove(entity);
            return _dbContext.SaveChanges();
        }
    }
}
