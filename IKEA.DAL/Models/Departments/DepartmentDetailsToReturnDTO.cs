using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IKEA.DAL.Models.Departments
{
    public class DepartmentDetailsToReturnDTO
    {
        public int Id {  get; set; }
        public string Name { get; set; } = null!;
        public string Description { get; set; } = null!;
        public string Code { get; set; } = null!;
        public DateOnly CreationDate { get; set; }
  
        public int CreatedBy { get; set; }
        public DateTime CreatedOn { get; set; }
        public int LastModificationBy { get; set; }
        public DateTime LastModificationOn { get; set; }
        public bool IsDeleted { get; set; }

    }
}
