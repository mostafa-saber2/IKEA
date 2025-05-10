using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IKEA.DAL.Models.Departments;
using IKEA.DAL.Presistance.Data;
using IKEA.DAL.Presistance.Repositories.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Client;

namespace IKEA.DAL.Presistance.Repositories.Departments
{
    public class DepartmentRespository :GenericRepository<Department>, IDepartmentRespository
    {
        public DepartmentRespository(ApplicationDbContext dbContext) : base(dbContext) { }
       
    }
}
