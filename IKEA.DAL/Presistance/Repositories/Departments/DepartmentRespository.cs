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
        private readonly ApplicationDbContext dbContext;

        public DepartmentRespository (ApplicationDbContext dbContext)
        {
          
            dbContext = dbContext;
        }
        public int Add(Department entity)
        {
            dbContext.Departments.Add(entity);
            return dbContext.SaveChanges();
            
        }

        public int Delete(Department entity)
        {
            dbContext.Departments.Remove(entity);
            return dbContext.SaveChanges();
        }

        public IEnumerable<Department> GetAll(bool WithNoTracking = true)
        {
            if (WithNoTracking)
            {
                dbContext.Departments.AsNoTracking().ToList();
            }
            return dbContext.Departments.ToList();
        }

        public Department? GetById(int id)
        {
            var Department = dbContext.Departments.Find(id);
            return Department;
        }

        public int Update(Department entity)
        {
            dbContext.Departments.Update(entity);
            return dbContext.SaveChanges();
        }
    }
}
