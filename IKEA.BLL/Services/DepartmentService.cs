using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IKEA.DAL.Models.Departments;
using IKEA.DAL.Presistance.Repositories.Departments;
using Microsoft.EntityFrameworkCore;

namespace IKEA.BLL.Services
{
    public class DepartmentService : IDepartmentService
    {
        private readonly IDepartmentRespository _departmentRespository;

        public DepartmentService(IDepartmentRespository departmentRespository)
        {
            _departmentRespository = departmentRespository;
        }
        //public IEnumerable<Department> GetAllDepartments()
        //{
        //    throw new NotImplementedException();
        //}

        public IEnumerable<DepartmentToReturnDTO> GetAllDepartmentsToReturn()
        {
            var departments = _departmentRespository.GetAllAsQuerable().Select(department => new DepartmentToReturnDTO
            {
                Id = department.Id,
                Name = department.Name,
                Code = department.Code,
            
                CreationDate = department.CreationDate,
            }).AsNoTracking().ToList();
            return departments;
           



            

            }
        

        public int CreateDepartment(CreatedDepartmentDTO departmentDTO)
        {
            
            var Createddepartments = new Department()
            {
                Code = departmentDTO.Code,
                Name = departmentDTO.Name,
                Description = departmentDTO.Description,
                CreationDate = departmentDTO.CreationDate,
                CreatedBy = 1,
                LastModificationBy = 1,
                LastModificationOn = DateTime.UtcNow
            };
            return _departmentRespository.Add(Createddepartments );
        }

        public bool DeleteDepartment(int id)
        {
            var departments=_departmentRespository.GetById(id);
            if(departments is not null)
            {
                return _departmentRespository.Delete(departments) > 0;
            }
            return false;
        }

     
    

        public DepartmentDetailsToReturnDTO? GetDepartmentById(int id)
        {
          var departments= _departmentRespository.GetById(id);
            if(departments is not  null)
            {
                return new DepartmentDetailsToReturnDTO
                {
                    Id = departments.Id,
                    Name = departments.Name,
                    Code = departments.Code,
                    Description = departments.Description,
                    CreationDate = departments.CreationDate,
                    CreatedBy = departments.CreatedBy,
                    CreatedOn = departments.CreatedOn,
                    LastModificationBy = departments.LastModificationBy,
                    LastModificationOn = departments.LastModificationOn,



                };
            }
           return null;
        }

        public int UpdateDepartment(UpdatedDepartmentDTO departmentDTO)
        {
            var Updateddepartments = new Department()
            {
                Id = departmentDTO.ID,
                Code = departmentDTO.Code,
                Name = departmentDTO.Name,
                Description = departmentDTO.Description,
                CreationDate = departmentDTO.CreationDate,
                CreatedBy = 1,
                LastModificationBy = 1,
                LastModificationOn = DateTime.UtcNow

            };
            return _departmentRespository.Update(Updateddepartments);
        }

        public IEnumerable<Department> GetAllDepartments()
        {
            throw new NotImplementedException();
        }
    }
}
