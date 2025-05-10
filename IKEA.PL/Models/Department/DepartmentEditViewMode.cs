using System.ComponentModel.DataAnnotations;

namespace IKEA.PL.Models.Department
{
    public class DepartmentEditViewMode
    {
        public string Name { get; set; } = null!;
        public string Description { get; set; } = null!;
        [Required(ErrorMessage ="Code Is required!!")]
        public string Code { get; set; } = null!;

        public DateOnly CreationDate { get; set; }
    }
}
