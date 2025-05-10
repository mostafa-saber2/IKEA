using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IKEA.DAL.Models;

using IKEA.DAL.Presistance.Data;
using Microsoft.EntityFrameworkCore;

namespace IKEA.DAL.Presistance.Repositories.Generic
{
    public class GenericRepository<T> : IGenericRepository<T> where T : ModelBase
    {
        private readonly ApplicationDbContext _dbContext;

        public GenericRepository(ApplicationDbContext dbContext)
        {

            _dbContext = dbContext;
        }
        public int Add(T entity)
        {
            _dbContext.Set<T>().Add(entity);
            return _dbContext.SaveChanges();

        }

        public int Delete(T entity)
        {
            _dbContext.Set<T>().Remove(entity);
            return _dbContext.SaveChanges();
        }

        public IEnumerable<T> GetAll(bool WithNoTracking = true)
        {
            if (WithNoTracking)
            {
                _dbContext.Set<T>().AsNoTracking().ToList();
            }
            return _dbContext.Set<T>().ToList();
        }

        public IQueryable<T> GetAllAsQuerable()
        {
            return _dbContext.Set<T>();
        }

        public T? GetById(int id)
        {
            var T = _dbContext.Set<T>().Find(id);
            return T;
        }

        public int Update(T entity)
        {
            _dbContext.Set<T>().Update(entity);
            return _dbContext.SaveChanges();
        }
    }
}
