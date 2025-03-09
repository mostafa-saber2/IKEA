using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IKEA.DAL.Models.Departments;
using IKEA.DAL.Presistance.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Client;

namespace IKEA.DAL.Presistance.Repositories.Departments
{
    public class DepartmentRespository : IDepartmentRespository
    {
        private readonly ApplicationDbContext _dbContext;

        public DepartmentRespository (ApplicationDbContext dbContext)
        {
          
            _dbContext = dbContext;
        }
        public int Add(Department entity)
        {
            _dbContext.Departments.Add(entity);
            return _dbContext.SaveChanges();
            
        }

        public int Delete(Department entity)
        {
            _dbContext.Departments.Remove(entity);
            return _dbContext.SaveChanges();
        }

        public IEnumerable<Department> GetAll(bool WithNoTracking = true)
        {
            if (WithNoTracking)
            {
                _dbContext.Departments.AsNoTracking().ToList();
            }
            return _dbContext.Departments.ToList();
        }

        public IQueryable<Department> GetAllAsQuerable()
        {
            return _dbContext.Departments;
        }

        public Department? GetById(int id)
        {
            var Department = _dbContext.Departments.Find(id);
            return Department;
        }

        public int Update(Department entity)
        {
            _dbContext.Departments.Update(entity);
            return _dbContext.SaveChanges();
        }
    }
}
