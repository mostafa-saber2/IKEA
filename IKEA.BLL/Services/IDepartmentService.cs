using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IKEA.DAL.Models.Departments;

namespace IKEA.BLL.Services
{
    public interface IDepartmentService
    {
        //IEnumerable<Department> AllDepartments { get; }

        IEnumerable<DepartmentToReturnDTO> GetAllDepartmentsToReturn();

        DepartmentDetailsToReturnDTO? GetDepartmentById(int id);

        int CreateDepartment(CreatedDepartmentDTO departmentDTO);
        int UpdateDepartment(UpdatedDepartmentDTO departmentDTO);
        bool DeleteDepartment(int id);


    }
}
